using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.Models;
using System.Threading.Tasks;

namespace App1.Data
{
    public class CollegeDB
    {
        readonly SQLiteAsyncConnection db;

        public CollegeDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<Student>().Wait();
            db.CreateTableAsync<Group>().Wait();
            db.CreateTableAsync<Faculty>().Wait();
            db.CreateTableAsync<Educator>().Wait();
        }

        //Student Table
        public Task<List<Student>> GetStudentsAsync()
        {
            return db.Table<Student>().OrderBy(x => x.FirstName).ToListAsync();
        }

        public Task<Student> GetStudentAsync(int id)
        {
            return db.Table<Student>()
                            .Where(i => i.StudentID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentAsync(Student student)
        {
            if (student.StudentID != 0) return db.UpdateAsync(student);
            else return db.InsertAsync(student);
        }

        public Task<int> DeleteStudentAsync(Student student)
        {
            return db.DeleteAsync(student);
        }

        //Group Table
        public Task<List<Group>> GetGroupsAsync()
        {
            return db.Table<Group>().OrderBy(x => x.GroupName).ToListAsync();
        }

        public Task<Group> GetGroupAsync(string GroupName)
        {
            return db.Table<Group>()
                            .Where(i => i.GroupName == GroupName)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveGroupAsync(Group group)
        {
            if (group.GroupName!= "") return db.UpdateAsync(group);
            else return db.InsertAsync(group);
        }

        public Task<int> DeleteGroupAsync(Group group)
        {
            return db.DeleteAsync(group);
        }

        //Faculty Table
        public Task<List<Faculty>> GetFacultiesAsync()
        {
            return db.Table<Faculty>().OrderBy(x => x.FacultyNumber).ToListAsync();
        }

        public Task<Faculty> GetFacultyAsync(string FacultyNumber)
        {
            return db.Table<Faculty>()
                            .Where(i => i.FacultyNumber == FacultyNumber)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFacultyAsync(Faculty faculty)
        {
            if (faculty.FacultyName!= "") return db.UpdateAsync(faculty);
            else return db.InsertAsync(faculty);
        }

        public Task<int> DeleteFacultyAsync(Faculty faculty)
        {
            return db.DeleteAsync(faculty);
        }

        //Educator Table
        public Task<List<Educator>> GetEducatorsAsync()
        {
            return db.Table<Educator>().OrderBy(x => x.Name).ToListAsync();
        }

        public Task<Educator> GetEducatorAsync(string EducatorNumber)
        {
            return db.Table<Educator>()
                            .Where(i => i.Name == EducatorNumber)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveEducatorAsync(Educator educator)
        {
            if (educator.Name!= "") return db.UpdateAsync(educator);
            else return db.InsertAsync(educator);
        }

        public Task<int> DeleteEducatorAsync(Educator educator)
        {
            return db.DeleteAsync(educator);
        }
    }
}
