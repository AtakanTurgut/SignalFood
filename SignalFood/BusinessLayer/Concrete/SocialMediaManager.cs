﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public List<SocialMedia> TGetAll()
        {
            return _socialMediaDal.GetAll();
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
