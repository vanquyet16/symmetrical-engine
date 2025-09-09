using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    public partial class DepartmentEmployeesForm : Form
    {
        private List<Employee> employees;

        public DepartmentEmployeesForm(string departmentName, List<Employee> employees)
        {
            InitializeComponent();
            this.employees = employees;
            this.Text = $"Nhân viên phòng ban: {departmentName}";
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = employees;
            dgvEmployees.Columns["EmployeeId"].Visible = false;
            dgvEmployees.Columns["DepartmentId"].Visible = false;
            dgvEmployees.Columns["PositionId"].Visible = false;
            dgvEmployees.Columns["CreatedDate"].Visible = false;
            dgvEmployees.Columns["UpdatedDate"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
