using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitateSmartisanNote
{
    public class NoteManager
    {
        private ObservableCollection<NoteItemModel> notes = new ObservableCollection<NoteItemModel>();

        public ObservableCollection<NoteItemModel> Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }
    }
}
