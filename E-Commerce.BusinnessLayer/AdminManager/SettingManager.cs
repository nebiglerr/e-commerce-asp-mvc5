using E_Commerce.BusinnessLayer.Result;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.AdminViewModel;
using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.AdminManager
{
    public class SettingManager
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<Seo> GetSeoList()
        {

            return _context.Seos.ToList();
        }
        public List<SocialMedia> GetSocialMediaList()
        {

            return _context.SocialMedias.ToList();
        }
        public List<SiteSetting> GetSiteSettingList()
        {

            return _context.SiteSettings.ToList();
        }
        public List<MailSetting> GetMailSettingList()
        {

            return _context.MailSettings.ToList();
        }
        public List<PrivacyPolicy> GetPrivacyPolicyList()
        {

            return _context.PrivacyPolicies.ToList();
        } 
        public List<MembershipAgreement> GetMembershipAgreementList()
        {

            return _context.MembershipAgreements.ToList();
        }
        public List<RefundConditions> GetRefundConditionsList()
        {

            return _context.RefundConditions.ToList();
        }
        public List<About> GetAboutList()
        {

            return _context.Abouts.ToList();
        }

        public BusiessLayerResult<Seo> SeoAdd(SeosAddViews seosAddViews)
        {
            BusiessLayerResult<Seo> res = new BusiessLayerResult<Seo>();

            Seo seo = _context.Seos.Where(x => x.Id == 1).FirstOrDefault();


            seo.Content = seosAddViews.Content;
            seo.Keyword = seosAddViews.Keyword;
            seo.Map = seosAddViews.Map;
            seo.Title = seosAddViews.Title;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<SocialMedia> SocialMediaAdd(SocialMediaAddViews socialMediaAddViews)
        {
            BusiessLayerResult<SocialMedia> res = new BusiessLayerResult<SocialMedia>();

            SocialMedia socialMedia = _context.SocialMedias.Where(x => x.Id == 1).FirstOrDefault();


            socialMedia.Facebook = socialMediaAddViews.Facebook;
            socialMedia.Instagram = socialMediaAddViews.Instagram;
            socialMedia.Twitter = socialMediaAddViews.Twitter;
            socialMedia.YouTube = socialMediaAddViews.YouTube;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<SiteSetting> SiteSettingAdd(SiteSettingAddViews siteSettingAddViews)
        {
            BusiessLayerResult<SiteSetting> res = new BusiessLayerResult<SiteSetting>();

            SiteSetting siteSetting = _context.SiteSettings.Where(x => x.Id == 1).FirstOrDefault();


            siteSetting.Adres = siteSettingAddViews.Adres;
            siteSetting.Email = siteSettingAddViews.Email;
            siteSetting.Telefon = siteSettingAddViews.Telefon;
            siteSetting.WhatsApp = siteSettingAddViews.WhatsApp;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<MailSetting> MailSettingAdd(MailSettingAddViews mailSettingAddViews)
        {
            BusiessLayerResult<MailSetting> res = new BusiessLayerResult<MailSetting>();

            MailSetting  mailSetting = _context.MailSettings.Where(x => x.Id == 1).FirstOrDefault();


            mailSetting.EmailPass = mailSettingAddViews.EmailPass;
            mailSetting.Email = mailSettingAddViews.Email;
            mailSetting.MailSender = mailSettingAddViews.MailSender;
            mailSetting.SenderInformation = mailSettingAddViews.SenderInformation;
            mailSetting.SmtpPort = mailSettingAddViews.SmtpPort;
            mailSetting.SmtpServer = mailSettingAddViews.SmtpServer;
            _context.SaveChanges();

            return res;
        }      
        public BusiessLayerResult<PrivacyPolicy> PrivacyPolicyAdd(PrivacyPolicyAddViews privacyPolicyAddViews)
        {
            BusiessLayerResult<PrivacyPolicy> res = new BusiessLayerResult<PrivacyPolicy>();

            PrivacyPolicy privacyPolicy  = _context.PrivacyPolicies.Where(x => x.Id == 1).FirstOrDefault();


            privacyPolicy.Content = privacyPolicyAddViews.Content;
            privacyPolicy.Keyword = privacyPolicyAddViews.Keyword;
            privacyPolicy.Title = privacyPolicyAddViews.Title;
            _context.SaveChanges();

            return res;
        } 
        public BusiessLayerResult<MembershipAgreement> MembershipAgreementAdd(MembershipAgreementAddViews membershipAgreementAddViews)
        {
            BusiessLayerResult<MembershipAgreement> res = new BusiessLayerResult<MembershipAgreement>();

            MembershipAgreement membershipAgreement  = _context.MembershipAgreements.Where(x => x.Id == 1).FirstOrDefault();


            membershipAgreement.Content = membershipAgreementAddViews.Content;
            membershipAgreement.Keyword = membershipAgreementAddViews.Keyword;
            membershipAgreement.Title = membershipAgreementAddViews.Title;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<RefundConditions> RefundConditionsAdd(RefundConditionsAddViews refundConditionsAddViews)
        {
            BusiessLayerResult<RefundConditions> res = new BusiessLayerResult<RefundConditions>();

            RefundConditions refundConditions  = _context.RefundConditions.Where(x => x.Id == 1).FirstOrDefault();


            refundConditions.Content = refundConditionsAddViews.Content;
            refundConditions.Keyword = refundConditionsAddViews.Keyword;
            refundConditions.Title = refundConditionsAddViews.Title;
            _context.SaveChanges();

            return res;
        } 
        public BusiessLayerResult<About> AboutAdd(AboutAddViews aboutAddViews)
        {
            BusiessLayerResult<About> res = new BusiessLayerResult<About>();

            About about  = _context.Abouts.Where(x => x.Id == 1).FirstOrDefault();


            about.Content = aboutAddViews.Content;
            about.Keyword = aboutAddViews.Keyword;
            about.Title = aboutAddViews.Title;
            _context.SaveChanges();

            return res;
        }
    }
}
