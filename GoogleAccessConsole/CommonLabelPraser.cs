﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;

namespace GoogleAccess
{
    public class CommonLabelPraser : ILabelPraser
    {
        public string Label
        {
            get;
            set;
        }

        public AddressCollection Prase<T>(string htmlContent)
        {
            Lexer lexer = new Lexer(htmlContent);
            Parser parser = new Parser(lexer);
            NodeFilter filter = new NodeClassFilter(typeof(T));

           
            NodeList  list  =   parser.ExtractAllNodesThatMatch(filter);
          

            AddressCollection col = new AddressCollection();
            if (list.Count > 0)
            {
                for (int j =0;j<list.Count;j++)
                {
                    
                    ATag link = (ATag) list[j];
                    var addr = new Address()
                    {
                        Text =  link.LinkText,
                        Href  =  link.Link
                    };

                    col.Collection.Add(addr);
                }
            }

            return col;
        }

    }
}
