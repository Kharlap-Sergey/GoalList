using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_
{
    public class Task
    {
        public Task()
        {

        }
        public Task(string content)
        {
            Content = content;
        }
        public string Content { get; set; }
        public int index { get; set; }
    }
}
