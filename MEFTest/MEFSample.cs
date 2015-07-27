using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFTest
{
    class MefSample
    {
        private CompositionContainer compositionContainer;

        [ImportMany]
        public IEnumerable<IExample> listofExamples;

        //[ImportMany] //Contract name must match!
        //public IEnumerable<Func<int>> DoSomething { get; set; }

        public MefSample()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("Assemblies"));
            compositionContainer = new CompositionContainer(catalog);
            try
            {
                this.compositionContainer.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }
        static void Main(string[] args)
        {
            var mefsample = new MefSample();
            foreach (var example in mefsample.listofExamples)
            {
                example.MyAddin();
            }
        }
    }
}