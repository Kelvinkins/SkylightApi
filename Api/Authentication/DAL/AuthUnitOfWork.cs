using Api.Authentication.DataContext;
using Api.Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication.DAL
{

 
        public class AuthUnitOfWork : IDisposable
        {
            private IdentityContext _Context;
            private AuthRepository<ApplicationUser> userRepository;
            private AuthRepository<AuditTrail> auditTrailRepository;
            private AuthRepository<ApplicationRole> roleRepository;
 
            public AuthUnitOfWork(IdentityContext Context)
            {
                _Context = Context;
            }
            public AuthRepository<ApplicationUser> UserRepository
                {
                    get
                    {

                        if (this.userRepository == null)
                        {
                            this.userRepository = new AuthRepository<ApplicationUser>(_Context);
                        }
                        return userRepository;
                    }
                }

        public AuthRepository<ApplicationRole> RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new AuthRepository<ApplicationRole>(_Context);
                }
                return roleRepository;
            }
        }
        public AuthRepository<AuditTrail> AuditTrailRepository
        {
            get
            {

                if (this.auditTrailRepository == null)
                {
                    this.auditTrailRepository = new AuthRepository<AuditTrail>(_Context);
                }
                return auditTrailRepository;
            }
        }




        public async Task Save()
            {
                await _Context.SaveChangesAsync();
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _Context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

    }

