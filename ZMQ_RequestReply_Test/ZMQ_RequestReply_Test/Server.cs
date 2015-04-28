using System;
using System.Threading;
using NetMQ;

namespace ZMQ_RequestReply_Test
{
	class MainClass : Client
	{
		public static void Main (string[] args)
		{
			NetMQContext context = NetMQContext.Create();
			NetMQSocket server = context.CreateRequestSocket ();
			server.Bind ("tcp://*:5555");
			NetMQMessage message = new NetMQMessage ();
			NetMQMessage getmass = new NetMQMessage ();
			message.Append ("Hallo ");
			message.Append(40);

			Client client = new Client ();
			Thread t = new Thread (new ThreadStart (client.runClient));
			t.Start ();


			while (true) {
				server.SendMessage(message,false);
				getmass = server.ReceiveMessage (false);
				System.Console.WriteLine (getmass.Pop ().ConvertToString());
				System.Console.WriteLine (getmass.Pop ().ConvertToInt32 ());
				
			}
		}
	}
}
