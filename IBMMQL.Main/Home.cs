using IBM.XMS;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBMMQL.Main
{
    public partial class Home : Form
    {
        private List<IBMMQConfig> iBMMQConfig;

        public Home()
        {
            InitializeComponent();
        }

        private void Start_Listner(object sender, EventArgs e)
        {
            iBMMQConfig = MessageQueueManager.IBMMessageQueueSettings;
            //List<Task> tasks = new List<Task>();
            for (int i = 0; i < iBMMQConfig.Count; i++)
            {
                IBMMQConfig config = iBMMQConfig[i];

                Task.Factory.StartNew(() =>
               {
                   SimpleResponse simpleResponse = new SimpleResponse();
                   simpleResponse.ReceiveMessagesFromEndpointNew(config);
               },CancellationToken.None);
            }
        }
    }
}
