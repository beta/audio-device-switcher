using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio_Device_Switcher.Data {
    /* 描述设备信息 */
    public class Device {
        private int id;
        private string name;
        private string description;
        private bool currentDefault;

        public Device(int id, string name, string description, bool currentDefault) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.currentDefault = currentDefault;
        }

        public int GetID() {
            return id;
        }

        public string GetName() {
            return name;
        }

        public string GetDescription() {
            return description;
        }

        public bool IsCurrentDefault() {
            return currentDefault;
        }
    }
}
