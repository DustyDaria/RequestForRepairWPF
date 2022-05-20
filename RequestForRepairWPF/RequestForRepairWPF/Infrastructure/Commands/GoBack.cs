using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands
{
    public class GoBack : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => PageManager.MainFrame.GoBack();

    }
}
