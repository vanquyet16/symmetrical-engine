using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    public partial class PositionEmployeesForm : Form
    {
        private List<Employee> employees;

        public PositionEmployeesForm(string positionName, List<Employee> employees)
        {
            InitializeComponent();
            this.employees = employees;
            this.Text = $"Nhân viên chức vụ: {positionName}";
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
