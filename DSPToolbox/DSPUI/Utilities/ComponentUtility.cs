using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using DSPUI.Components;

namespace DSPUI.Utilities
{
    public static class ComponentUtility
    {
        public static bool ComponentAttributesHasSignal(Component c)
        {
            if (c == null)
                return false;

            ComponentAttributes ca = c.Data;

            foreach (var field in ca.GetType().GetFields())
            {
                if (field.FieldType.Equals(typeof(Signal)))
                    return true;
            }

            foreach (var prop in ca.GetType().GetProperties())
            {
                if (prop.PropertyType.Equals(typeof(Signal)))
                    return true;
            }
            return false;
        }
        public static Signal GetSignalFromComponentAttributes(ComponentAttributes ca)
        {
            foreach (var field in ca.GetType().GetFields())
            {
                if (field.FieldType.Equals(typeof(Signal)))
                    return (Signal)ca.GetType().GetProperty(field.Name).GetValue(ca, null);
            }

            foreach (var prop in ca.GetType().GetProperties())
            {
                if (prop.PropertyType.Equals(typeof(Signal)))
                    return (Signal)ca.GetType().GetProperty(prop.Name).GetValue(ca, null);
            }
            return null;
        }
    }
}
