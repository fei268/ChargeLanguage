实现功能：通过config配置文件实现多语言版本的程序。
只实用于窗体不多的小软件。

Class1.cs文件：遍历窗体控件，从配置文件中查找同名字的配置项并返回相应值，如果没有，返回控件名称；然后根据控件名称在配置文件中增加相应配置项即可。

App.config文件：configSections必须在configuration下第一个节点；name命名规则自定，但要统一。

Form1.cs主窗体文件：关键代码 foreach (Control control in this.Controls).....部分控件需要二次判断，不然识别不到。菜单，数据窗口等不在循环控件内，直接调用方法即可。
主要调用方法 Class1.Chargs(this.Name, control.Name) ；this.Name=窗体名称，control.Name=控件名称。
新窗口文件如果需要程序内部切换语言，new From2(c.chr)的时候需要传值。此操作跟数据窗口标题栏一样需要重新打开，但无需关闭主窗体。

其他Form2.cs弹出窗口（或内嵌pancel）文件：关键代码foreach (Control control in this.Controls).....DateTimePicker控件似乎有问题，需要排除。
如果要跟随主窗口内部切换，需要增加public Form3(string str).....接受参数。


4.28	测试程序多语言功能，感觉使用resx文件配置也不是那么方便，使用config配置文件试试；

5.9	增加弹窗中语言跟随主窗口变换（打开后变换不跟随）；增加dataGridView标题栏文字判断，程序内切换语言需要重新获取数据，如果是初始化dataGridView1需要额外判断

