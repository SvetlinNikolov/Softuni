using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responces;
using SIS.HTTP.Responces.Contracts;
using SIS.WebServer.Result;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IServerRoutingTable serverRoutingTable;
        private IHttpRequest ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesToread = this.client.Receive(data.Array, SocketFlags.None);

                if (numberOfBytesToread == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesToread);
                result.Append(bytesAsString);

                if (numberOfBytesToread < 1023)
                {
                    break;
                }

                if (result.Length == 0)
                {
                    return null;
                }


            }
            return new HttpRequest(result.ToString());

        }
        private IHttpResponce HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Contains(httpRequest.RequestMethod, httpRequest.Path))
            {
                return new TextResult(@$"Route with method {httpRequest.RequestMethod} and path \{httpRequest.Path}\ not found.", HttpResponceStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path).Invoke(httpRequest);
        }
        private void PrepareResponce(IHttpResponce httpResponce)
        {
            byte[] byteSegments = httpResponce.GetBytes();

            this.client.Send(byteSegments, SocketFlags.None);
        }
        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }
        public void ProcessRequest()
        {
            IHttpResponce httpResponce = null;

            try
            {
                IHttpRequest httpRequest = this.ReadRequest();

                if (httpRequest != null)
                {
                    Console.WriteLine($"{httpRequest.RequestMethod} {httpRequest.Path}...");
                    httpResponce = this.HandleRequest(httpRequest);
                }
            }
            catch (BadRequestException e)
            {

                httpResponce = new TextResult(e.Message, HttpResponceStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                httpResponce = new TextResult(e.Message, HttpResponceStatusCode.InternalServerError);
            }

            this.PrepareResponce(httpResponce);
            this.client.Shutdown(SocketShutdown.Both);
        }
    }
}
