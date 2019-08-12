using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SubInvestorSetup.Models;
using Microsoft.AspNetCore.Identity;
using SubInvestorSetup.Interface;
using Microsoft.AspNetCore.Authorization;

namespace SubInvestorSetup.Controllers
{

 
    public class InvestorLinkController : Controller
    {
        private readonly InvestorContext _context;
        private readonly IInvestorLink _investorLink;

        public InvestorLinkController(InvestorContext context, IInvestorLink investorLinkInject)
        {
            _context = context;
            _investorLink = investorLinkInject;
        }

        // GET: InvestorLink
        public async Task<IActionResult> Index()
        {
            var investorLink = await _context.InvestorLinks.ToListAsync();            

            return View(investorLink.OrderByDescending(i => i.InvestorSetupId));
            //return View(await _context.InvestorLinks.ToListAsync());
        }

        // GET: InvestorLink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var investorLink = await _context.InvestorLinks
            //    .FirstOrDefaultAsync(m => m.InvestorSetupId == id);


            //Interface for Dependancy Injection

            //var investorLink = _investorLinkRepo.GetInvestorLink(id);
            var investorLink = _investorLink.GetInvestorLinkSubInvestors(id);


            if (investorLink == null)
            {
                return NotFound();
            }

            return View(investorLink);
        }

        // GET: InvestorLink/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvestorLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("InvestorSetupId,Description,InvestorNo,InvestorSubFrom,InvestorSubTo,ModelAfterInvestorNo,ModelAfterInvestorSub,CreatedDate,CreatedBy,ApprovedDate,ApprovedBy,DeployedDate,DeployedBy,DeletedDate,DeletedBy,DeletedReason,Status = 1")] InvestorLink investorLink)
        {


            if (ModelState.IsValid)
                try
                {

                    investorLink.Status = EnumStatus.New;
                    investorLink.CreatedDate = DateTime.Now;
                    investorLink.CreatedBy = User.Identity.Name;
                    _context.Add(investorLink);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }


            return View(investorLink);
        }

        // GET: InvestorLink/Delete/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var model = new ReportingInvestorViewModel();

            //var investorLink = await _context.InvestorLinks
            //    .FirstOrDefaultAsync(m => m.InvestorSetupId == id);

            //if (investorLink == null)
            //{
            //    return NotFound();
            //}

            //model.InvestorLink = investorLink;
            //var status = investorLink.Status;

            ////Get InvestorLink detail
            //if (status != EnumStatus.Deleted)
            //{

            //    List<ReportingInvestorLink> lst = _context.ReportingInvestorLink
            //                       .FromSql("ups_GetSubInvestors @p0, @p1", id, status)
            //                       .ToList();
            //    model.ReportingInvestorLink = lst;
            //}
            //else
            //{
            //    model.ReportingInvestorLink = null;
            //}

            //using DI
            var model =  _investorLink.GetInvestorLinkSubInvestors(id);

            return View(model);
        }

        // POST: InvestorLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var investorLink = await _context.InvestorLinks.FindAsync(id);

            //if (investorLink.Status != EnumStatus.Deployed)
            //{
            //    _context.InvestorLinks.Remove(investorLink);


            //}
            //else
            //{
            //    _context.ReportingInvestorLink.FromSql("ups_BackoutSubInvestors @p0", id);
            //    //TODO: Get Reason Code
            //    investorLink.DeletedReason = "Deleted From Production";
            //    // investorLink.DeletedSubInvestorCount = rawsAffected.Count();
            //}

            _investorLink.DeleteInvestorLinkSubInvestors(id);

            investorLink.Status = EnumStatus.Deleted;
            investorLink.DeletedBy = User.Identity.Name;
            investorLink.DeletedDate = DateTime.Now;
            await _context.SaveChangesAsync();

           
            return RedirectToAction(nameof(Index));
        }

        // GET: InvestorLink/Approve/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var investorLink = await _context.InvestorLinks
            //    .FirstOrDefaultAsync(m => m.InvestorSetupId == id);

            var investorLink = _investorLink.GetInvestorLinkSubInvestors(id);

            if (investorLink == null)
            {
                return NotFound();
            }

            return View(investorLink);
        }

        // POST: InvestorLink/Approve/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ApproveConfirmed(int id)
        {
            var investorLink = await _context.InvestorLinks.FindAsync(id);

            if (investorLink.Status == EnumStatus.New)
            {
                investorLink.Status = EnumStatus.Approved;
                investorLink.ApprovedDate = DateTime.Now;
                investorLink.ApprovedBy = User.Identity.Name;

                await _context.SaveChangesAsync();

            }
            else
            {
                ViewData["ApproveError"] = "Only NEW investor setup can be approved";
            }

            //var investorri = await _context.ReportingInvestorLinkStage.FindAsync(1, "000002000","00009");
            //_context.ReportingInvestorLinkStage.Remove(investorri);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: InvestorLink/Approve/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Deploy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var investorLink = await _context.InvestorLinks
            //    .FirstOrDefaultAsync(m => m.InvestorSetupId == id);

            var investorLink =  _investorLink.GetInvestorLinkSubInvestors(id);

            if (investorLink == null)
            {
                return NotFound();
            }

            return View(investorLink);
        }

        // POST: InvestorLink/Deploy/5
        [HttpPost, ActionName("Deploy")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeployConfirmed(int id)
        {
            var investorLink = await _context.InvestorLinks.FindAsync(id);
       
            if(investorLink.Status == EnumStatus.Approved)
            {
                _context.Database.ExecuteSqlCommand("ups_InsertNewSubInvestors @p0", id);

                investorLink.Status = EnumStatus.Deployed;
                investorLink.DeployedDate = DateTime.Now;
                investorLink.DeployedBy = User.Identity.Name;

                await _context.SaveChangesAsync();

            }
            else
            {
                ViewData["DeployError"] = "Approval is needed before deploying to Production";

                return View("Views/InvestorLink/Deploy.cshtml");
            }

            //var investorri = await _context.ReportingInvestorLinkStage.FindAsync(1, "000002000","00009");
            //_context.ReportingInvestorLinkStage.Remove(investorri);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool InvestorLinkExists(int id)
        {
            return  _context.InvestorLinks.Any(e => e.InvestorSetupId == id);
        }
    }
}
