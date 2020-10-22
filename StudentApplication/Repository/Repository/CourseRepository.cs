using IData;
using IRepository.IRepository;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class CourseRepository :BaseRepository<Course>, ICourseRepository
    {
        private readonly Icontext _icontext;
        public CourseRepository(Icontext icontext) : base(icontext)
        {
            _icontext = icontext;
        }
    }
}
