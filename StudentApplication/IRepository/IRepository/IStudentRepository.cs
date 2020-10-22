using DtoLayer.DTOModel;
using Models.DataModels;
using System.Collections.Generic;
namespace IRepository.IRepository
{
    public interface IStudentRepository: _IAllRepository<Student>
    {
        bool AddStudent(Student std, string courseId);
        bool DleteStudent(int id);
        List<FullStudentDto> GettAllStudents(Pager pager);
        FullStudentDtoo SearchStudent(int stdid);
        bool UpdateStudent(Student UpdateStd, string CourseArray);
    }
}
