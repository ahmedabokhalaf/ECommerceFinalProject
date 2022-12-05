using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.ElectroDev.Presentation
{


	public class RoleController : Controller
	{
		RoleManager<IdentityRole> RoleManager;
		public RoleController(RoleManager<IdentityRole> roleManager)
		{
			RoleManager = roleManager;
		}


		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult Add()
		{

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Add(RoleCreateModel model)
		{

			if (ModelState.IsValid == false)
				return View();
			else
			{
				var result =
				await RoleManager.CreateAsync(
					new IdentityRole
					{
						Name = model.Name
					});
				if (result.Succeeded == false)
				{
					result.Errors.ToList().ForEach(i =>
					{
						ModelState.AddModelError("", i.Description);
					});
					return View();
				}
				else
				{
					return RedirectToAction("SignUp", "User");
				}

			}
		}
		//[HttpGet]
		//[Authorize(Roles = "Admin")]
		//public IActionResult Delete()
		//{

		//	return View();
		//}


		//[HttpPost]
		//public async Task<IActionResult> Delete(RoleCreateModel model)
		//{

		//	if (ModelState.IsValid == false)
		//		return View();
		//	else
		//	{
		//		var result =
		//		await RoleManager.DeleteAsync(
		//			new IdentityRole
		//			{
		//				Id=model.Id,
		//				Name = model.Name
		//			});
		//		if (result.Succeeded == false)
		//		{
		//			result.Errors.ToList().ForEach(i =>
		//			{
		//				ModelState.AddModelError("", i.Description);
		//			});
		//			return View();
		//		}
		//		else
		//		{
		//			return RedirectToAction("SignUp", "User");
		//		}

		//	}
		//}
	}
}