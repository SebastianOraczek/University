using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;

namespace MN_SO_APS_PROJECT.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public CommentController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentModel comment)
        {
            try
            {
                string id = _userManager.GetUserId(User);

                CommentModel? newComment = new CommentModel { Id = comment.Id, Content = comment.Content, ApplicationUserId = id };

                _db.Comment.Add(newComment);
                _db.SaveChanges();

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult List()
        {
            string id = _userManager.GetUserId(User);
            List<CommentModel>? DbComments = _db.Comment.ToList();
            List<CommentModel> comments = new List<CommentModel>();

            foreach (var c in DbComments)
            {
                if (c.ApplicationUserId == id)
                    comments.Add(c);
            }

            ViewBag.Comments = comments;

            return View(comments);
        }

        public ActionResult AllComments()
        {
            List<CommentModel>? comments = _db.Comment.ToList();
            ViewBag.Comments = comments;

            return View(ViewBag);
        }

        public ActionResult Delete(string id, CommentModel comments)
        {
            try
            {
                var commentToDelete = _db.Comment.FirstOrDefault(x => x.ApplicationUserId == id);

                _db.Comment.Remove(commentToDelete);

                _db.SaveChanges();

                return RedirectToAction(nameof(AllComments));
            }
            catch
            {
                return RedirectToAction(nameof(AllComments));
            }
        }

    }
}
