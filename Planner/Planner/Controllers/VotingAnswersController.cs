using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Planner;
using Planner.Models;

namespace Planner.Controllers
{
    public class VotingAnswersController : Controller
    {
        private PlannerContext db = new PlannerContext();

        // GET: VotingAnswers
        public async Task<ActionResult> Index()
        {
            return View(await db.VotingAnswer.ToListAsync());
        }

        // GET: VotingAnswers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = await db.VotingAnswer.FindAsync(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            return View(votingAnswer);
        }

        // GET: VotingAnswers/Create
        public ActionResult Create(int? id)
        {
            VotingAnswer votingAnswer = new VotingAnswer();
            votingAnswer.VotingId = id.GetValueOrDefault();
            return View(votingAnswer);
        }
        
        
        // POST: VotingAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VotingAnswerId,AnswerText,VotingId")] VotingAnswer votingAnswer)
        {
            if (ModelState.IsValid)
            {
                db.VotingAnswer.Add(votingAnswer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(votingAnswer);
        }        
        // GET: VotingAnswers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = await db.VotingAnswer.FindAsync(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            return View(votingAnswer);
        }

        // POST: VotingAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VotingAnswerId,AnswerText")] VotingAnswer votingAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votingAnswer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(votingAnswer);
        }

        // GET: VotingAnswers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = await db.VotingAnswer.FindAsync(id);
            if (votingAnswer == null)
            {
                return HttpNotFound();
            }
            return View(votingAnswer);
        }

        // POST: VotingAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VotingAnswer votingAnswer = await db.VotingAnswer.FindAsync(id);
            db.VotingAnswer.Remove(votingAnswer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
