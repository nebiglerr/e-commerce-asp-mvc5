using E_Commerce.AdminApp.Models;
using E_Commerce.BusinnessLayer.AdminManager;
using E_Commerce.Entities.AdminViewModel;
using System.Web.Mvc;

namespace E_Commerce.AdminApp.Controllers
{
    [UseAuthorize]
    public class HomeController : Controller
    {

        private readonly SettingManager _settingManager = new SettingManager();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Setting()
        {
            ViewBag.Seo = _settingManager.GetSeoList();
            ViewBag.SocialMedia = _settingManager.GetSocialMediaList();
            ViewBag.SiteSetting = _settingManager.GetSiteSettingList();
            ViewBag.MailSetting = _settingManager.GetMailSettingList();
            return View();
        }

        [HttpPost]
        public ActionResult Seo(SeosAddViews seosAddViews)
        {

            var res = _settingManager.SeoAdd(seosAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(seosAddViews);
            }
            return RedirectToAction("Setting");
        }
        [HttpPost]
        public ActionResult SocialMedia(SocialMediaAddViews socialMediaAddViews)
        {

            var res = _settingManager.SocialMediaAdd(socialMediaAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(socialMediaAddViews);
            }
            return RedirectToAction("Setting");
        }

        [HttpPost]
        public ActionResult SiteSetting(SiteSettingAddViews siteSettingAddViews)
        {

            var res = _settingManager.SiteSettingAdd(siteSettingAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(siteSettingAddViews);
            }
            return RedirectToAction("Setting");
        }
        [HttpPost]
        public ActionResult MailSetting(MailSettingAddViews mailSettingAddViews)
        {

            var res = _settingManager.MailSettingAdd(mailSettingAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(mailSettingAddViews);
            }
            return RedirectToAction("Setting");
        }

        public ActionResult Content()
        {
            ViewBag.PrivacyPolicy = _settingManager.GetPrivacyPolicyList();
            ViewBag.MembershipAgreement = _settingManager.GetMembershipAgreementList();
            ViewBag.RefundConditions = _settingManager.GetRefundConditionsList();
            ViewBag.About = _settingManager.GetAboutList();
            return View();
        }

        [HttpPost]
        public ActionResult PrivacyPolicy(PrivacyPolicyAddViews privacyPolicyAddViews)
        {

            var res = _settingManager.PrivacyPolicyAdd(privacyPolicyAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(privacyPolicyAddViews);
            }
            return RedirectToAction("Content");
        }
        [HttpPost]
        public ActionResult MembershipAgreement(MembershipAgreementAddViews membershipAgreementAddViews)
        {

            var res = _settingManager.MembershipAgreementAdd(membershipAgreementAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(membershipAgreementAddViews);
            }
            return RedirectToAction("Content");
        }
        [HttpPost]
        public ActionResult RefundConditions(RefundConditionsAddViews refundConditionsAddViews)
        {

            var res = _settingManager.RefundConditionsAdd(refundConditionsAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(refundConditionsAddViews);
            }
            return RedirectToAction("Content");
        }
        [HttpPost]
        public ActionResult About(AboutAddViews aboutAddViews)
        {

            var res = _settingManager.AboutAdd(aboutAddViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(aboutAddViews);
            }
            return RedirectToAction("Content");
        }
    }
}