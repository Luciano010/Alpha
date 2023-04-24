using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using Activity = SomerenModel.Activity;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlTeachers.Hide();
            pnlKassa.Hide();

            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlKassa.Hide();
            pnlTeachers.Hide();
            pnlDashboard.Hide();


            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void ShowTeachersPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlKassa.Hide();

            // show Teachers
            pnlTeachers.Show();

            try
            {
                // get and display all teachers
                List<Teacher> teachers = GetTeachers();
                DisplayTeachers(teachers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
            }
        }
        private List<Teacher> GetTeachers()
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeachers();
            return teachers;
        }

        private void DisplayTeachers(List<Teacher> teachers)
        {
            listViewTeachers.Clear();

            foreach (Teacher teacher in teachers)
            {
                ListViewItem firstName = new ListViewItem(teacher.firstName);
                firstName.Tag = teacher;
                listViewTeachers.Items.Add(firstName);

                ListViewItem lastName = new ListViewItem(teacher.lastName);
                lastName.Tag = teacher;
                listViewTeachers.Items.Add(lastName);

                ListViewItem phoneNumber = new ListViewItem(teacher.phoneNumber.ToString());
                phoneNumber.Tag = teacher;
                listViewTeachers.Items.Add(phoneNumber);

                ListViewItem role = new ListViewItem(teacher.Role);
                role.Tag = teacher;
                listViewTeachers.Items.Add(role);

                ListViewItem age = new ListViewItem(teacher.Age.ToString());
                age.Tag = teacher;
                listViewTeachers.Items.Add(age);
                listViewTeachers.Items.Add("\n");
                listViewTeachers.Items.Add("\n");
                listViewTeachers.Items.Add("\n");
            }

            //teacherDataGridView.DataSource = teachers;
        }


        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();

            foreach(Student student in students)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = student;
                item.SubItems.Add(student.FirstName);   
            }

            return students;
        }

        private void DisplayStudents(List<Student> students)
        {
            //studentDataGridView.DataSource = students;

            listViewStudents.Clear();

            foreach (Student student in students)
            {
                ListViewItem firstName = new ListViewItem(student.FirstName);
                firstName.Tag = student;
                listViewStudents.Items.Add(firstName);

                ListViewItem lastName = new ListViewItem(student.LastName);
                lastName.Tag = student;
                listViewStudents.Items.Add(lastName);

                ListViewItem number = new ListViewItem(student.Number.ToString());
                number.Tag = student;
                listViewStudents.Items.Add(number);
                listViewStudents.Items.Add("\n");
            }
        }



        //Kassa / Drinks
        private void ShowKassaPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlTeachers.Hide();
            pnlStudents.Hide();

            // show Kassa
            pnlKassa.Show();

            try
            {
                // get and display all drinks
                //List<Drinks> drinks = GetDrinks();
                //DisplayDrinks(drinks);
                DisplayDrinks();

                // get and display all students
                List<Student> students = GetStudents();
                DisplayDrinksStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
            }
        }

        private List<Drinks> GetDrinks()
        {
            DrinksService drinksService = new DrinksService();
            List<Drinks> drinks = drinksService.GetDrinks();

            return drinks;
        }

        private void DisplayDrinksStudents(List<Student> students)
        {
            //listViewKassa.Clear();

            foreach (Student student in students)
            {
                ListViewItem firstName = new ListViewItem(student.FirstName);
                firstName.Tag = student;
                listViewStudent.Items.Add(firstName);

                ListViewItem lastName = new ListViewItem(student.LastName);
                lastName.Tag = student;
                listViewStudent.Items.Add(lastName);

                ListViewItem number = new ListViewItem(student.Number.ToString());
                number.Tag = student;
                listViewStudent.Items.Add(number);
            }

            //studentDrinksDataGridView.DataSource = students;
        }

        private void DisplayDrinks()//List<Drinks> drinks)
        {
            listViewDrinks.Items.Clear();

            List<Drinks> drinks = GetDrinks();

            foreach (Drinks drink in drinks)
            {
                ListViewItem drinkItem = new ListViewItem(drink.drinkName);
                drinkItem.Tag = drink;
                drinkItem.SubItems.Add(drink.price.ToString());
                drinkItem.SubItems.Add(drink.stock.ToString());
                drinkItem.SubItems.Add(drink.isAlcoholic.ToString());
                listViewDrinks.Items.Add(drinkItem);

                /*
                ListViewItem drinkName = new ListViewItem(drink.drinkName);
                drinkName.Tag = drink;
                listViewDrinks.Items.Add(drinkName);

                ListViewItem price = new ListViewItem(drink.price.ToString());
                price.Tag = drink;
                listViewDrinks.Items.Add(price);

                ListViewItem stock = new ListViewItem(drink.stock.ToString());
                stock.Tag = drink;
                listViewDrinks.Items.Add(stock);

                ListViewItem isAlcoholic = new ListViewItem(drink.isAlcoholic.ToString());
                isAlcoholic.Tag = drink;
                listViewDrinks.Items.Add(isAlcoholic);

                */
            }

            //drinksDataGridView.DataSource = drinks;
        }



        private List<Activity> GetActivities()
        {
            ActivityService activityService = new ActivityService();
            List<Activity> activities = activityService.GetAllActivities();
            return activities;
        }

        private List<ActivitySupervisor> GetActivitiesSupervisor()
        {
            ActivityService activityService = new ActivityService();
            List<ActivitySupervisor> activitySupervisors = activityService.GetAllActivitySupervisors();
            return activitySupervisors;
        }




        private void dashboardToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void lecturersButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTeachersPanel();
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTeachersPanel();
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowKassaPanel();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void studentDrinksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string name = studentDrinksDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            ////if (studentDrinksDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            ////{
            ////    name = studentDrinksDataGridView.SelectedCells[0].Value.ToString();
            ////}

            //label4.Text = name;
        }

        private void btnCheckout_Click_1(object sender, EventArgs e)
        {
            DrinksService drinksService = new DrinksService();

            try
            {
                Drinks drink = (Drinks)listViewDrinks.SelectedItems[0].Tag;

                drink.stock -= 1;

                drinksService.UpdateStock(drink);

                DisplayDrinks();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a drink");
            }
        }

        private void listViewKassa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panelActivitySupervisor_Paint(object sender, PaintEventArgs e)
        {


            // hide all other panels
            pnlDashboard.Hide();
            pnlTeachers.Hide();
            pnlStudents.Hide();
            pnlKassa.Hide();

            // show Activity Supervisors
            panelActivitySupervisor.Show();
            updateActivitySupervisors();
        }

        private void updateActivitySupervisors()
        {
            listViewAltTeachers.Items.Clear();
            listViewActivities.Items.Clear();
            listViewActivitySupervisor.Items.Clear();

            foreach(Activity activity in GetActivities())
            {
                ListViewItem activityItem = new ListViewItem(activity.ActivitiyName);
                activityItem.SubItems.Add(activity.StartTime.ToString());
                activityItem.SubItems.Add(activity.FinishTime.ToString());
                activityItem.Tag = activity;
                listViewActivities.Items.Add(activityItem);
            }

            foreach (Teacher teacher in GetTeachers())
            {
                ListViewItem teacherItem = new ListViewItem(teacher.firstName + " " + teacher.lastName);
                teacherItem.Tag = teacher;
                listViewAltTeachers.Items.Add(teacherItem);
            }

            foreach(ActivitySupervisor activitySupervisor in GetActivitiesSupervisor())
            {
                ListViewItem activitySupervisorItem = new ListViewItem(activitySupervisor.Activity.ActivitiyName);
                activitySupervisorItem.SubItems.Add(activitySupervisor.Teacher.firstName + " " + activitySupervisor.Teacher.lastName);
                activitySupervisorItem.Tag = activitySupervisor;
                listViewActivitySupervisor.Items.Add(activitySupervisorItem);
            }
        }

        private void btnAddSupervisor_Click(object sender, EventArgs e)
        {

            ActivitySupervisor activitySupervisor = new ActivitySupervisor(this.activity.ActivityId, this.teacher.teacherId);

            ActivityService activityService = new ActivityService();
            activityService.AddActivitySupervisor(activitySupervisor);
            updateActivitySupervisors();
        }

        private Teacher teacher;
        private Activity activity;
        private ActivitySupervisor activitySupervisor;

        private void listViewAltTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.teacher = (Teacher)listViewAltTeachers.SelectedItems[0].Tag;
        }

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.activity = (Activity)listViewActivities.SelectedItems[0].Tag;
        }

        private void btnRemoveSupervisor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this supervisor?", "Remove Supervisor", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ActivityService activityService = new ActivityService();
                activityService.RemoveActivitySupervisor(this.activitySupervisor);
                updateActivitySupervisors();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void listViewActivitySupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.activitySupervisor = (ActivitySupervisor)listViewActivitySupervisor.SelectedItems[0].Tag;
        }
    }
}