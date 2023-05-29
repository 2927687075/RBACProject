using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.Model;
using RBACProject.IRepository;

namespace RBACProject.Repository
{
    public class LoginInfoRepository: BaseRepository<LoginInfoModel>,ILoginRepository 
    {
    }
}
