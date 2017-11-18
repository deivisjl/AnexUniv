using Common;
using Microsoft.Owin.Logging;
using Model.Auth;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    //public interface IUserService { }

    public class UserService //: IUserService
    {
        /*private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;

        public UserService(
            IDbContextScopeFactory dbContextScopeFactory, 
            IRepository<ApplicationUser> applicationUserRepo) {

            this._dbContextScopeFactory = dbContextScopeFactory;
            this._applicationUserRepo = applicationUserRepo;

        }

        public ResponseHelper Update(ApplicationUser model) {

            var rh = new ResponseHelper();
            try {

                using (var ctx = _dbContextScopeFactory.Create()) {

                    var originalModel = _applicationUserRepo.Single(x => x.Id == model.Id);
                    originalModel.Name = model.Name;
                    originalModel.LastName = model.LastName;

                    _applicationUserRepo.Update(originalModel);
                    rh.SetResponse(true);
                }

            } catch (Exception e) {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }*/
    }
}
