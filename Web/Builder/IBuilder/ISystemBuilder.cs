using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Builder.IBuilder
{
    public interface ISystemBuilder
    {
        ISystemBuilder AddMemory(string memory);
        ISystemBuilder AddDrive(string size);

        ISystemBuilder AddKeyboard(string type);
        ISystemBuilder AddMouse(string type);

        ISystemBuilder AddTouchScreen(string enabled);

        ComputerSystem GetSystem();
    }
}
