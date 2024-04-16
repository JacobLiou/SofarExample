using Castle.Components.DictionaryAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    internal class CatsleDemo
    {

        private readonly Hashtable hashtable
            = new Hashtable();

        public void DoSomething()
        {
            hashtable.Add("key1", 111);
            hashtable.Add("Key2", "goody");
            hashtable["key1"] = new Dictionary<string, string>();

        }

        public void UseDicAdaptor()
        {
            var dic = new Hashtable();
            dic["Echo"] = "Hello";
            var factory = new DictionaryAdapterFactory();
            var adaptor = factory.GetAdapter<IHelloWorld>(dic);
            Console.Write(adaptor.Echo());
        }
    }

    interface IHelloWorld
    {
        string Echo();
    }

    public class HelloWorld : IHelloWorld
    {
        public string Echo()
        {
            return "Hello";
        }
    }
}
