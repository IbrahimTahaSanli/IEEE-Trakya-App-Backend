using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEEEBACKEND.Models
{
    public class Header
    {
        public int _PhotoPath;
        public string _Title;
        public int _Content;

        public Header() { }
        public Header(int PhotoPath, string Title, int Content) {
            _PhotoPath = PhotoPath;
            _Title = Title;
            _Content = Content;
        }

        public string ToString()
        {
            return "{ \"PhotoPath\": \"" + _PhotoPath + "\", \"Title\": \"" + _Title + "\", \"Content\": \"" + _Content + "\"}";
        }
    }
}
