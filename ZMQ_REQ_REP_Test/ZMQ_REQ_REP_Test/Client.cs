﻿using System;
using NetMQ;

namespace ZMQ_RequestReply_Test
{
	public class Client
	{

		public void runClient(){
			NetMQContext context = NetMQContext.Create ();
			NetMQSocket client = context.CreateResponseSocket ();
			client.Connect ("tcp://localhost:5555");
			NetMQMessage message = new NetMQMessage ();
			NetMQMessage message2 = new NetMQMessage ();
			while (true) {

				message = client.ReceiveMessage (false);
				message2.Append (message.Pop ().ConvertToString () + "Tobi");
				message2.Append (message.Pop ().ConvertToInt32 () + 12);
				client.SendMessage (message2, false);
				System.Threading.Thread.Sleep (100);

			}
		}
	}
}