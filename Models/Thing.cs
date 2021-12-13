using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEEEBACKEND.Models
{
    public class Thing
    {
        public string _Title;
        public int _HeaderPhoto;
        public string _Description;
        public int _Content;
        public string _CommitteeName;
        public string _DateAdded;
        
        public Thing() { }
        public Thing(string Committee, string Title, int HeaderPhoto, string Description, int Content, string DateAdded)
        {
            _CommitteeName = Committee;
            _Title = Title;
            _HeaderPhoto = HeaderPhoto;
            _Description = Description;
            _Content = Content;
            _DateAdded = DateAdded;
        }

        public string ToString()
        {
            return "{ \"Title\": \"" + _Title + "\", \"HeaderPhoto\": \"" + _HeaderPhoto + "\", \"Description\": \"" + _Description + "\", \"Content\": \"" + _Content + "\", \"CommitteeName\": \"" + _CommitteeName + "\", \"DateAdded\": \"" + _DateAdded + "\" }";  
        }
    }
}
