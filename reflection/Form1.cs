using System.Reflection;

namespace reflection
{
    public partial class Form1 : Form
    {
        Assembly[] assemblies;
        Type[] types;
        public Form1()
        {
            InitializeComponent();
            //1. yol
            AppDomain appDomain = AppDomain.CurrentDomain;
            assemblies = appDomain.GetAssemblies();
            /*2. yol
            Assembly assemblies = Assembly.GetExecutingAssembly();
            listBox1.Items.Add(assemblies.Location);*/
            foreach (Assembly assembly in assemblies)
                listBox1.Items.Add(assembly.Location);
            //3. yol Assembly assemblies = Assembly.LoadFrom(yol);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Assembly assembly = assemblies[listBox1.SelectedIndex];
            types=assembly.GetTypes();
            foreach (Type type in types)
            {
                
                listBox2.Items.Add(type.FullName);
            }
                
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberInfo[] memberInfos = types[listBox2.SelectedIndex].GetMembers();
            foreach (MemberInfo memberInfo in memberInfos)
            {
                listBox3.Items.Add(memberInfo.Name+"->"+memberInfo.MemberType);
            }
            MethodInfo[] methodInfos = types[listBox2.SelectedIndex].GetMethods();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                listBox4.Items.Add(methodInfo.Name);
            }
        }
    }
}