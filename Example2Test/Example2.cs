// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Example1.cs" company="Microsoft"> 
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
//   THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR 
//   OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
//   ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR 
//   OTHER DEALINGS IN THE SOFTWARE. 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;

namespace MEFTest
{
    [Export(typeof (IExample))]
    public class Example2 : IExample, IPartImportsSatisfiedNotification
    {
        public void MyAddin()
        {
            Console.WriteLine("In Example 2 class");
        }

        public void OnImportsSatisfied()
        {
            Console.WriteLine("Example 2 Imports satisfied");
        }

        [Export(typeof (Func<int>))]
        public void sample1(int x)
        {
            Console.WriteLine("Sample 1");
        }
    }

    //[Export(typeof(IExample))]
    public class Example3 : IExample
    {
        public void MyAddin()
        {
            Console.WriteLine("In Example 3 class");
        }

        [Export(typeof (Func<int>))]
        public void sample1(int x)
        {
            Console.WriteLine("Sample 2");
        }
    }
}