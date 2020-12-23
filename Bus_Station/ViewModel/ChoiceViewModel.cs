using Bus_Station.Auth;
using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    public class ChoiceViewModel : IRequireViewIdentification
    {
        public ChoiceViewModel ()
        {
            _viewId = Guid.NewGuid();
        }
        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }
        
        private RelayCommand editRoute;
        public RelayCommand EditRoute
        {
            get
            {
                return editRoute ??
                    (editRoute = new RelayCommand(obj =>
                    {
                        TimeTable timeTable = new TimeTable();
                        timeTable.ShowDialog();
                    }));
            }
        }

        private RelayCommand createReport;
        public RelayCommand CreateReport
        {
            get
            {
                return createReport ??
                    (createReport = new RelayCommand(obj =>
                    {
                        Diagram diagram = new Diagram();
                        diagram.ShowDialog();
                    }));
            }
        }

        private RelayCommand changeUser;
        public RelayCommand ChangeUser
        {
            get
            {
                return changeUser ??
                    (changeUser = new RelayCommand(obj =>
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.ShowDialog();
                        WindowManager.CloseWindow(ViewID);
                    }));
            }
        }
    }
}
