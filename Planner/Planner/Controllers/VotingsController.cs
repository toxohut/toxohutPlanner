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
    public class VotingsController : Controller
    {
        private PlannerContext db = new PlannerContext();

        // GET: Votings
        public async Task<ActionResult> Index()
        {
            return View(await db.Voting.ToListAsync());
        }

        // GET: Votings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voting voting = await db.Voting.FindAsync(id);
            if (voting == null)
            {
                return HttpNotFound();
            }
            return View(voting);
        }

        // GET: Votings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Votings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VotingId,Name,Description,IsOpenQuestion")] Voting voting)
        {
            if (ModelState.IsValid)
            {
                db.Voting.Add(voting);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voting);
        }



        // GET: Votings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voting voting = await db.Voting.FindAsync(id);
            if (voting == null)
            {
                return HttpNotFound();
            }
            return View(voting);
        }
     

        // POST: Votings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VotingId,Name,Description,IsOpenQuestion")] Voting voting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voting).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voting);
        }

        // GET: Votings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voting voting = await db.Voting.FindAsync(id);
            if (voting == null)
            {
                return HttpNotFound();
            }
            return View(voting);
        }

        // POST: Votings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Voting voting = await db.Voting.FindAsync(id);
            db.Voting.Remove(voting);
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

  //      public async Task<ActionResult> Edit(int? id)
        public ActionResult CreateAnswer(int? id)
        {//przerobić na przeładowane create
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotingAnswer votingAnswer = new VotingAnswer();
            votingAnswer.VotingId = id.GetValueOrDefault();
            return View(votingAnswer);

            //return RedirectToAction("Create", "VotingAnswers", id);
        }
    }
}
