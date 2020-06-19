using AmigoWallet.UserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmigoWallet.UserService.Repository
{
    public class UserRepository
    {
        UserDBContext _context;
        public UserRepository(UserDBContext context)
        {
            _context = context;

        }

        public int ValidateCredentials(string emailId, string password)
        {
            try
            {
                var userdetail = (from user in _context.UserDetails where user.EmailId == emailId && user.Password == password select user).FirstOrDefault();
                if (userdetail != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int RegisterUser(UserDetails userDetails)
        {
            try
            {
                var user = _context.UserDetails.Find(userDetails.EmailId);
                if (user == null)
                {
                    _context.UserDetails.Add(userDetails);
                    _context.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ValidateUserId(string emailId)
        {
            try
            {
                var user = _context.UserDetails.Find(emailId);
                if (user == null)
                {
                    return 0;

                }
                else
                {
                    return 1;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       public int UpdatePassword(UserDetails userDetails)
        {
            try
            {
                var entity = _context.UserDetails.FirstOrDefault(i => i.EmailId == userDetails.EmailId);

                if (entity != null)
                {
                    
                    entity.Password = userDetails.Password;
                    // Update entity in DbSet
                    _context.UserDetails.Update(entity);
                    // Save changes in database
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}