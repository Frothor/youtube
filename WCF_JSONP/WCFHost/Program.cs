using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{


    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public DateTime OrderDate { get; set; }
    }

    [ServiceContract]
    public interface IOrder
    {
        [OperationContract]
        [WebGet(UriTemplate ="/GetAll",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        List<Order> GetAll();
    }


    [ServiceBehavior]
    public class OrderService : IOrder
    {
        [OperationBehavior]
        public List<Order> GetAll()
        {
            return new List<Order>()
            {
                new Order{Id=1,Name="Mobile",OrderDate=DateTime.Now.AddHours(1)},
                new Order{Id=2,Name="Laptop",OrderDate=DateTime.Now.AddHours(2)},
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrderService));
            host.Open();
            Console.WriteLine("Service is ready");
            Console.ReadLine();
        }
    }
}
