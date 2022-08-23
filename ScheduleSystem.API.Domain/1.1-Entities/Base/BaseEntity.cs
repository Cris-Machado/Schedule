using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.API.Domain._2._1_Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public void Create()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            IsDeleted = false;
        }
        public void Update()
        {
            UpdateDate = DateTime.Now;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
