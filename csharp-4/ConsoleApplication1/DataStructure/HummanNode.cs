using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1.DataStructure
{
    public class HummanNode : Node<object>
    {
        public HummanNode(object value) : base(value)
        {
        }

        public static void GetIncodedList(Node<int> node, ref List<string> codeList, StringBuilder code = null) {
            if (code == null) {
                code = new StringBuilder("");
            }
            if (node == null) {
                code.Length--;
            } else {
                code.Append('0');
                GetIncodedList(node.Left, ref codeList, code);
                code.Append('1');
                GetIncodedList(node.Right, ref codeList, code);
                if (node.Right == null && node.Left == null) {
                    codeList.Add(code.ToString());
                }
                code.Length = (code.Length > 0) ? code.Length - 1 : 0;
            }
        }
    }
}