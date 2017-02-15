using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MitiankinContacts.Models
{
    public class TypeModelView
    {
        public TypeModelView(int value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
        public int Value { get; set; }
        public string Text { get; set; }
    }
}