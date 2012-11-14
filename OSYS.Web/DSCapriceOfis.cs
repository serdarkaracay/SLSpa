
namespace OSYS.Web
{
    using NUtils.Login.Dto;
    using OSYS.Web.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.EntityClient;
    using System.Data.SqlClient;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the Caprice_OfisEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DSCapriceOfis : LinqToEntitiesDomainService<Caprice_OfisEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DepartmanGorevler' query.
        public IQueryable<DepartmanGorevler> GetDepartmanGorevler()
        {
            return this.ObjectContext.DepartmanGorevler;
        }

        public void InsertDepartmanGorevler(DepartmanGorevler departmanGorevler)
        {
            if ((departmanGorevler.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(departmanGorevler, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DepartmanGorevler.AddObject(departmanGorevler);
            }
        }

        public void UpdateDepartmanGorevler(DepartmanGorevler currentDepartmanGorevler)
        {
            this.ObjectContext.DepartmanGorevler.AttachAsModified(currentDepartmanGorevler, this.ChangeSet.GetOriginal(currentDepartmanGorevler));
        }

        public void DeleteDepartmanGorevler(DepartmanGorevler departmanGorevler)
        {
            if ((departmanGorevler.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(departmanGorevler, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DepartmanGorevler.Attach(departmanGorevler);
                this.ObjectContext.DepartmanGorevler.DeleteObject(departmanGorevler);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Departmanlar' query.
        public IQueryable<Departmanlar> GetDepartmanlar()
        {
            return this.ObjectContext.Departmanlar;
        }

        public void InsertDepartmanlar(Departmanlar departmanlar)
        {
            if ((departmanlar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(departmanlar, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Departmanlar.AddObject(departmanlar);
            }
        }

        public void UpdateDepartmanlar(Departmanlar currentDepartmanlar)
        {
            this.ObjectContext.Departmanlar.AttachAsModified(currentDepartmanlar, this.ChangeSet.GetOriginal(currentDepartmanlar));
        }

        public void DeleteDepartmanlar(Departmanlar departmanlar)
        {
            if ((departmanlar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(departmanlar, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Departmanlar.Attach(departmanlar);
                this.ObjectContext.Departmanlar.DeleteObject(departmanlar);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Personel' query.
        public IQueryable<Personel> GetPersonel()
        {
            return this.ObjectContext.Personel;
        }

        public void InsertPersonel(Personel personel)
        {
            if ((personel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personel, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Personel.AddObject(personel);
            }
        }

        public void UpdatePersonel(Personel currentPersonel)
        {
            this.ObjectContext.Personel.AttachAsModified(currentPersonel, this.ChangeSet.GetOriginal(currentPersonel));
        }

        public void DeletePersonel(Personel personel)
        {
            if ((personel.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personel, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Personel.Attach(personel);
                this.ObjectContext.Personel.DeleteObject(personel);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PersonelIzinDatalari' query.
        public IQueryable<PersonelIzinDatalari> GetPersonelIzinDatalari()
        {
            return this.ObjectContext.PersonelIzinDatalari;
        }

        public void InsertPersonelIzinDatalari(PersonelIzinDatalari personelIzinDatalari)
        {
            if ((personelIzinDatalari.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personelIzinDatalari, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PersonelIzinDatalari.AddObject(personelIzinDatalari);
            }
        }

        public void UpdatePersonelIzinDatalari(PersonelIzinDatalari currentPersonelIzinDatalari)
        {
            this.ObjectContext.PersonelIzinDatalari.AttachAsModified(currentPersonelIzinDatalari, this.ChangeSet.GetOriginal(currentPersonelIzinDatalari));
        }

        public void DeletePersonelIzinDatalari(PersonelIzinDatalari personelIzinDatalari)
        {
            if ((personelIzinDatalari.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personelIzinDatalari, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PersonelIzinDatalari.Attach(personelIzinDatalari);
                this.ObjectContext.PersonelIzinDatalari.DeleteObject(personelIzinDatalari);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PersonelProfili' query.
        public IQueryable<PersonelProfili> GetPersonelProfili()
        {
            return this.ObjectContext.PersonelProfili;
        }

        public void InsertPersonelProfili(PersonelProfili personelProfili)
        {
            if ((personelProfili.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personelProfili, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PersonelProfili.AddObject(personelProfili);
            }
        }

        public void UpdatePersonelProfili(PersonelProfili currentPersonelProfili)
        {
            this.ObjectContext.PersonelProfili.AttachAsModified(currentPersonelProfili, this.ChangeSet.GetOriginal(currentPersonelProfili));
        }

        public void DeletePersonelProfili(PersonelProfili personelProfili)
        {
            if ((personelProfili.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personelProfili, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PersonelProfili.Attach(personelProfili);
                this.ObjectContext.PersonelProfili.DeleteObject(personelProfili);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'User' query.
        public IQueryable<User> GetUser()
        {
            return this.ObjectContext.User;
        }

        public void InsertUser(User user)
        {
            if ((user.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(user, EntityState.Added);
            }
            else
            {
                this.ObjectContext.User.AddObject(user);
            }
        }

        public void UpdateUser(User currentUser)
        {
            this.ObjectContext.User.AttachAsModified(currentUser, this.ChangeSet.GetOriginal(currentUser));
        }

        public void DeleteUser(User user)
        {
            if ((user.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(user, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.User.Attach(user);
                this.ObjectContext.User.DeleteObject(user);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserApplications' query.
        public IQueryable<UserApplications> GetUserApplications()
        {
            return this.ObjectContext.UserApplications;
        }

        public void InsertUserApplications(UserApplications userApplications)
        {
            if ((userApplications.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userApplications, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserApplications.AddObject(userApplications);
            }
        }

        public void UpdateUserApplications(UserApplications currentUserApplications)
        {
            this.ObjectContext.UserApplications.AttachAsModified(currentUserApplications, this.ChangeSet.GetOriginal(currentUserApplications));
        }

        public void DeleteUserApplications(UserApplications userApplications)
        {
            if ((userApplications.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userApplications, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserApplications.Attach(userApplications);
                this.ObjectContext.UserApplications.DeleteObject(userApplications);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserAppRoles' query.
        public IQueryable<UserAppRoles> GetUserAppRoles()
        {
            return this.ObjectContext.UserAppRoles;
        }

        public void InsertUserAppRoles(UserAppRoles userAppRoles)
        {
            if ((userAppRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userAppRoles, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserAppRoles.AddObject(userAppRoles);
            }
        }

        public void UpdateUserAppRoles(UserAppRoles currentUserAppRoles)
        {
            this.ObjectContext.UserAppRoles.AttachAsModified(currentUserAppRoles, this.ChangeSet.GetOriginal(currentUserAppRoles));
        }

        public void DeleteUserAppRoles(UserAppRoles userAppRoles)
        {
            if ((userAppRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userAppRoles, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserAppRoles.Attach(userAppRoles);
                this.ObjectContext.UserAppRoles.DeleteObject(userAppRoles);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserRightDefinitions' query.
        public IQueryable<UserRightDefinitions> GetUserRightDefinitions()
        {
            return this.ObjectContext.UserRightDefinitions;
        }

        public void InsertUserRightDefinitions(UserRightDefinitions userRightDefinitions)
        {
            if ((userRightDefinitions.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRightDefinitions, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserRightDefinitions.AddObject(userRightDefinitions);
            }
        }

        public void UpdateUserRightDefinitions(UserRightDefinitions currentUserRightDefinitions)
        {
            this.ObjectContext.UserRightDefinitions.AttachAsModified(currentUserRightDefinitions, this.ChangeSet.GetOriginal(currentUserRightDefinitions));
        }

        public void DeleteUserRightDefinitions(UserRightDefinitions userRightDefinitions)
        {
            if ((userRightDefinitions.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRightDefinitions, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserRightDefinitions.Attach(userRightDefinitions);
                this.ObjectContext.UserRightDefinitions.DeleteObject(userRightDefinitions);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserRoleDetails' query.
        public IQueryable<UserRoleDetails> GetUserRoleDetails()
        {
            return this.ObjectContext.UserRoleDetails;
        }

        public void InsertUserRoleDetails(UserRoleDetails userRoleDetails)
        {
            if ((userRoleDetails.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRoleDetails, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserRoleDetails.AddObject(userRoleDetails);
            }
        }

        public void UpdateUserRoleDetails(UserRoleDetails currentUserRoleDetails)
        {
            this.ObjectContext.UserRoleDetails.AttachAsModified(currentUserRoleDetails, this.ChangeSet.GetOriginal(currentUserRoleDetails));
        }

        public void DeleteUserRoleDetails(UserRoleDetails userRoleDetails)
        {
            if ((userRoleDetails.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRoleDetails, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserRoleDetails.Attach(userRoleDetails);
                this.ObjectContext.UserRoleDetails.DeleteObject(userRoleDetails);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserRoles' query.
        public IQueryable<UserRoles> GetUserRoles()
        {
            return this.ObjectContext.UserRoles;
        }

        public void InsertUserRoles(UserRoles userRoles)
        {
            if ((userRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRoles, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserRoles.AddObject(userRoles);
            }
        }

        public void UpdateUserRoles(UserRoles currentUserRoles)
        {
            this.ObjectContext.UserRoles.AttachAsModified(currentUserRoles, this.ChangeSet.GetOriginal(currentUserRoles));
        }

        public void DeleteUserRoles(UserRoles userRoles)
        {
            if ((userRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userRoles, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserRoles.Attach(userRoles);
                this.ObjectContext.UserRoles.DeleteObject(userRoles);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_PersonelIzin' query.
        public IQueryable<View_SPA_PersonelIzin> GetView_SPA_PersonelIzin()
        {
            return this.ObjectContext.View_SPA_PersonelIzin;
        }

        public void InsertView_SPA_PersonelIzin(View_SPA_PersonelIzin view_SPA_PersonelIzin)
        {
            if ((view_SPA_PersonelIzin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_PersonelIzin, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_PersonelIzin.AddObject(view_SPA_PersonelIzin);
            }
        }

        public void UpdateView_SPA_PersonelIzin(View_SPA_PersonelIzin currentView_SPA_PersonelIzin)
        {
            this.ObjectContext.View_SPA_PersonelIzin.AttachAsModified(currentView_SPA_PersonelIzin, this.ChangeSet.GetOriginal(currentView_SPA_PersonelIzin));
        }

        public void DeleteView_SPA_PersonelIzin(View_SPA_PersonelIzin view_SPA_PersonelIzin)
        {
            if ((view_SPA_PersonelIzin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_PersonelIzin, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_PersonelIzin.Attach(view_SPA_PersonelIzin);
                this.ObjectContext.View_SPA_PersonelIzin.DeleteObject(view_SPA_PersonelIzin);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_PersonelProfil' query.
        public IQueryable<View_SPA_PersonelProfil> GetView_SPA_PersonelProfil()
        {
            return this.ObjectContext.View_SPA_PersonelProfil;
        }

        public void InsertView_SPA_PersonelProfil(View_SPA_PersonelProfil view_SPA_PersonelProfil)
        {
            if ((view_SPA_PersonelProfil.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_PersonelProfil, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_PersonelProfil.AddObject(view_SPA_PersonelProfil);
            }
        }

        public void UpdateView_SPA_PersonelProfil(View_SPA_PersonelProfil currentView_SPA_PersonelProfil)
        {
            this.ObjectContext.View_SPA_PersonelProfil.AttachAsModified(currentView_SPA_PersonelProfil, this.ChangeSet.GetOriginal(currentView_SPA_PersonelProfil));
        }

        public void DeleteView_SPA_PersonelProfil(View_SPA_PersonelProfil view_SPA_PersonelProfil)
        {
            if ((view_SPA_PersonelProfil.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_PersonelProfil, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_PersonelProfil.Attach(view_SPA_PersonelProfil);
                this.ObjectContext.View_SPA_PersonelProfil.DeleteObject(view_SPA_PersonelProfil);
            }
        }

        #region CustomQuery


        Guid TKMBayanDepartman = Guid.Parse("80A41632-1815-46A4-8D46-0F70DB0CC2D0");
        Guid TKMErkekDepartman = Guid.Parse("9E84B9A1-D5EF-4A20-BB46-3DFC39EF53EA");

        public void LoginUser(string username, string password)
        {
            string applicationName = "Spa";
            NUtils.Login.Authentication newAuthentication = new NUtils.Login.Authentication(applicationName);
            Kullanici userLogin;

            try
            {
                userLogin = newAuthentication.KullaniciKontrol(username, password);
            }
            catch (Exception)
            {
                
            }
            

        }


        public IQueryable<DTO.DbLogin> GetLogin(string userName, string password)
        {
            IQueryable<DTO.DbLogin> result = from p in ObjectContext.Personel
                                             join u in ObjectContext.User on p.OID equals u.EmployeeId
                                             where (u.LoginName == userName && u.Password == password ||
                                             p.DepartmanID == TKMBayanDepartman && p.DepartmanID == TKMErkekDepartman)
                                             select new DTO.DbLogin()
                                             {
                                                 PersonelID = p.OID,
                                                 Username = u.LoginName,
                                                 Password = u.Password,
                                                 DepartmanID = p.DepartmanID ?? Guid.Empty,
                                                 PersonelName = p.Adi,
                                                 PersonelGorevID = p.GorevID
                                             };
            return result.AsQueryable();
        }

        DTO.DbLogin dl = new DTO.DbLogin();

        public void UpdateDLogin(DTO.DbLogin login)
        {
            dl = login;
        }

        /// <summary>
        /// AutoComplete için Kullanılan Methot
        /// </summary>
        /// <param name="personelAdi">Personel Adı</param>
        /// <returns>List</returns>
        public IQueryable<DTO.DbPersonel> GetPersonelByPersonelAdi(string personelAdi)
        {
            IQueryable<DTO.DbPersonel> result = from p in ObjectContext.Personel
                                                where p.Adi.StartsWith(personelAdi) || p.DepartmanID == TKMBayanDepartman && p.DepartmanID == TKMErkekDepartman
                                                select new DbPersonel()
                                                {

                                                    PersonelAdi = p.Adi,
                                                    ID = p.OID

                                                };
            return result.AsQueryable();
        }

        DTO.DbPersonel dbPersonel = new DbPersonel();
        public void UpdateDPersonel(DTO.DbPersonel Personel)
        {
            dbPersonel = Personel;
        }

        //27.08.2012
        public IQueryable<Personel> GetPersonelByFizyoterapist()
        {
            string fizyo = "67CD2921-FE0B-48BA-B920-20BE504E5EC5";
            Guid _fizyo = new Guid(fizyo);

            return ObjectContext.Personel.Where(p => p.GorevID == _fizyo);
        }

        //19.07.2012 Resimdosyaları için ve AutoComplete için ViewOluşturuldu.
        public IQueryable<View_SPA_PersonelProfil> GetViewPersonelProfil(string Adi)
        {
            return ObjectContext.View_SPA_PersonelProfil.Where(p => p.Adi.StartsWith(Adi));
        }
        #endregion
    }
}


