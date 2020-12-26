using Bus_Station.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    public class MessageViewModel : IRequireViewIdentification
    {
         public MessageViewModel()
        {
            _viewId = Guid.NewGuid();
         }

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        private RelayCommand closeWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return closeWindow ??
                    (closeWindow = new RelayCommand(obj =>
                    {
                        WindowManager.CloseWindow(ViewID);
                    }));
            }
        }
    }
}
