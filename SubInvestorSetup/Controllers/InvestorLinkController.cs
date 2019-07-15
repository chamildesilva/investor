using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubInvestorSetup.Models;

namespace SubInvestorSetup.Controllers
{
    public class InvestorLinkController : Controller
    {
        private readonly InvestorContext _context;

        public InvestorLinkController(InvestorContext context)
        {
            _context = context;
        }

        // GET: InvestorLink
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvestorLinks.ToListAsync());
        }

        // GET: InvestorLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investorLink = await _context.InvestorLinks
                .FirstOrDefaultAsync(m => m.InvestorSetupId == id);
            if (investorLink == null)
            {
                return NotFound();
            }

            return View(investorLink);
        }

        // GET: InvestorLink/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvestorLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvestorSetupId,Description,InvestorNo,InvestorSubFrom,InvestorSubTo,ModelAfterInvestorNo,ModelAfterInvestorSub,CreatedDate,CreatedBy,ApprovedDate,ApprovedBy,DeployedDate,DeployedBy,DeletedDate,DeletedBy,DeletedReason,Status = 1")] InvestorLink investorLink)
        {
            if (ModelState.IsValid)
            {

                investorLink.Status = Status.New;
                _context.Add(investorLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investorLink);
        }

        // GET: InvestorLink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investorLink = await _context.InvestorLinks.FindAsync(id);
            if (investorLink == null)
            {
                return NotFound();
            }
            return View(investorLink);
        }

        // POST: InvestorLink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvestorSetupId,Description,InvestorNo,InvestorSubFrom,InvestorSubTo,ModelAfterInvestorNo,ModelAfterInvestorSub,CreatedDate,CreatedBy,ApprovedDate,ApprovedBy,DeployedDate,DeployedBy,DeletedDate,DeletedBy,DeletedReason,Status")] InvestorLink investorLink)
        {
            if (id != investorLink.InvestorSetupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investorLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestorLinkExists(investorLink.InvestorSetupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(investorLink);
        }

        // GET: InvestorLink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investorLink = await _context.InvestorLinks
                .FirstOrDefaultAsync(m => m.InvestorSetupId == id);
            if (investorLink == null)
            {
                return NotFound();
            }

            return View(investorLink);
        }

        // POST: InvestorLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investorLink = await _context.InvestorLinks.FindAsync(id);
            _context.InvestorLinks.Remove(investorLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestorLinkExists(int id)
        {
            return _context.InvestorLinks.Any(e => e.InvestorSetupId == id);
        }
    }
}
