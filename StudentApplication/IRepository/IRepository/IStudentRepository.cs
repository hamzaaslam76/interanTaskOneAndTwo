using DtoLayer.DTOModel;
using Models.DataModels;
using System.Collections.Generic;
namespace IRepository.IRepository
{
    public interface IStudentRepository: _IAllRepository<Student>
    {
        bool AddStudent(StudentDto std, List<string> courseId);
        bool DleteStudent(int id);
        List<FullStudentDto> GettAllStudents(Pager pager);
        FullStudentDtoo SearchStudent(int stdid);
        bool UpdateStudent(StudentDto UpdateStd, List<string> CourseArray);
    }
}
