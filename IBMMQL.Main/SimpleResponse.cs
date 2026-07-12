using IBM.XMS;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IBMMQL.Main
{
    public class SimpleResponse
    {
        private const int TIMEOUTTIME = 30000;
        private bool keepRunning = true;

        public static IConnectionFactory SetConnectionProperties(IBMMQConfig config)
        {
            try
            {
                IConnectionFactory cf;
                XMSFactoryFactory factoryFactory;
                // Get an instance of factory.
                factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);

                // Create WMQ Connection Factory.
                cf = factoryFactory.CreateConnectionFactory();

                // Set the properties             
                cf.SetStringProperty(XMSC.WMQ_HOST_NAME, config.IpAddress);
                cf.SetIntProperty(XMSC.WMQ_PORT, config.PortNumber);
                cf.SetStringProperty(XMSC.WMQ_CHANNEL, config.ChannelName);
                cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, config.QueueManagerName);
                cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
                cf.SetIntProperty(XMSC.WMQ_BROKER_VERSION, XMSC.WMQ_BROKER_V1);

                if (!string.IsNullOrEmpty(config.UserName))
                {
                    cf.SetStringProperty(XMSC.USERID, config.UserName);
                    cf.SetStringProperty(XMSC.PASSWORD, config.Password);
                }
                return cf;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReceiveMessagesFromEndpoint(IBMMQConfig config)
        {
            IConnection connectionWMQ;
            ISession sessionWMQ;
            IDestination destination;
            IMessageConsumer consumer;
            ITextMessage textMessage;
            IConnectionFactory cf = SetConnectionProperties(config);

            // Create connection.
            connectionWMQ = cf.CreateConnection();
            Console.WriteLine("Connection created");

            // Create session
            sessionWMQ = connectionWMQ.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
            Console.WriteLine("Session created");

            // Create destination
            destination = sessionWMQ.CreateQueue(config.QueueName);
            Console.WriteLine("Destination created");

            // Create consumer
            consumer = sessionWMQ.CreateConsumer(destination);
            Console.WriteLine("Consumer created");

            // Start the connection to receive messages.
            connectionWMQ.Start();
            Console.WriteLine("Connection started");

            Console.WriteLine("Receive message: " + TIMEOUTTIME / 1000 + " seconds wait time");
            // Wait for 30 seconds for messages. Exit if no message by then
            do
            {
                textMessage = (ITextMessage)consumer.Receive();
                if (textMessage != null)
                {

                    Console.WriteLine("Message received.");
                    Console.Write(textMessage);
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Wait timed out.");
                    keepRunning = false;
                }

            }
            while (keepRunning);


            // Cleanup
            consumer.Close();
            destination.Dispose();
            sessionWMQ.Dispose();
            connectionWMQ.Close();
        }

        public void ReceiveMessagesFromEndpointNew(IBMMQConfig config)
        {

            try
            {
                //XMSFactoryFactory factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
                //// Use the connection factories factory to create a connection factory
                //IConnectionFactory connfactory = factoryFactory.CreateConnectionFactory();
                IConnectionFactory cf = SetConnectionProperties(config);
                cf.SetIntProperty(XMSC.WPM_TARGET_TRANSPORT_CHAIN_SECURE, XMSC.WMQ_CM_CLIENT_UNMANAGED);
                ITextMessage textMessage;

                // Create connetion factory using config
                using (IConnection conn = cf.CreateConnection())
                {
                    // Create session
                    using (ISession session = conn.CreateSession(false, AcknowledgeMode.AutoAcknowledge))
                    {

                        using (IDestination dest = session.CreateQueue(config.QueueName)) // Create a topic
                        {
                            dest.SetIntProperty(XMSC.DELIVERY_MODE, XMSC.DELIVERY_NOT_PERSISTENT);
                            using (IMessageConsumer consumer = session.CreateConsumer(dest))
                            {
                                conn.Start();
                                do
                                {
                                    textMessage = (ITextMessage)consumer.Receive();
                                    if (textMessage != null)
                                    {
                                        // Get the parent form
                                        Home myForm = new Home();
                                        myForm.lblMQ1.Text = textMessage.Text;
                                        System.Diagnostics.Debug.WriteLine("Message from \"" + config.QueueName + "\"received.");
                                        System.Diagnostics.Debug.WriteLine("Message: " + textMessage.Text);
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("Wait timed out.");
                                        keepRunning = false;
                                    }

                                }
                                while (keepRunning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                ReceiveMessagesFromEndpointNew(config);
                throw;
            }
        }
        public void ReceiveMessagesFromEndpointByList(List<IBMMQConfig> iBMMQConfigs)
        {
            //try
            //{
            //    string connectionNames = string.Empty;
            //    for (int i = 0; i < iBMMQConfigs.Count; i++)
            //    {
            //        connectionNames += connectionNames + string.Format("{0}({1})", iBMMQConfigs[i].IpAddress, iBMMQConfigs[i].PortNumber) + ",";

            //    }
            //    string connectionName = "fred.mq.com(2344),nick.mq.com(3746),tom.mq.com(4288)";
            //    Hashtable properties = new Hashtable();
            //    properties.Add(XMSC.WMQ_CONNECTION_NAME_LIST, connectionName);
            //    using (IConnection conn = cf.CreateConnection())
            //    {

            //    }
            //    MQQueueManager qmgr = new MQQueue Manager("qmgrname", properties);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }
    }
}
