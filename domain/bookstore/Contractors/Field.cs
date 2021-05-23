using System;
using System.Collections.Generic;
using System.Text;

namespace store.Contractors
{
    public abstract class Field
    {
        public string Label { get; }

        public string Name { get; }

        public string Value { get; }

        protected Field(string label, string name, string val)
        {
            Label = label;
            Name = name;
            Value = val;
        }
    }


        public class HiddenField : Field
        {
            public HiddenField(string label, string name, string val)
                                                    : base(label, name, val) { }

        }

        public class SelectionField : Field
        {
        public IReadOnlyDictionary<string, string> Items { get; }
            public SelectionField(string label, string name, string val, IReadOnlyDictionary<string, string> items)
                                                    : base(label, name, val)

        {
            Items = items;
        }

        }
    }
    
