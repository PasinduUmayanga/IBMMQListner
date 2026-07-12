using System;
using System.Collections.Generic;
using System.IO;

namespace IBMMQL.Main
{
    public class MessageQueueManager
    {
        #region Private properties
        private static MessageQueueConfig messageQueueConfig = new MessageQueueConfig();
        private static string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MessageQueueConfig.json");
        private static DateTime lastWriteTime = DateTime.MinValue;
        #endregion
        /// <summary>
        /// Load latest file to memory
        /// </summary>
        private static void LoadLatestFileToMemory()
        {
            try
            {
                if (File.GetLastWriteTime(configFilePath) != lastWriteTime)
                {
                    using (StreamReader streamReader = new StreamReader(configFilePath))
                    {
                        string jsonText = streamReader.ReadToEnd();
                        messageQueueConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageQueueConfig>(jsonText);
                    }
                    lastWriteTime = File.GetLastWriteTime(configFilePath);
                }
            }
            catch (IOException ioex)
            {         
                throw ioex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// IBM message queue settings
        /// </summary>
        /// <returns>IBMMQConfig object</returns>
        public static List<IBMMQConfig> IBMMessageQueueSettings
        {
            get
            {
                LoadLatestFileToMemory();
                return messageQueueConfig.IBMMQ_ENDPOINTS;
            }
        }
    }
}
