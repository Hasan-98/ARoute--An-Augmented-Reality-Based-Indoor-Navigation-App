using System;
using System.Collections.Generic;
using System.Linq;
using using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

public class CreateMap : MonoBehaviour
{
    private string mapName = "GenericMap";
    private custumShapeManager shape;
    private bool isMapSaved = false;
    private unityARInterface interface;
    private bool ArRouteObject = false;
    private bool isPointInserted = false;


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddHttpContextAccessor();
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(1000);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });


        services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BookingContext")));



    }

    private void Initalized()
    {

    }
    public void saveMap()
    {
        if (isMapSaved)
        {
            saveMap = false;
        }
        if (!interface.Initalized()){

            }
        }
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("UserID,Mapname,Map<Node>,isMapSaved")] unityARInterface AR)
{
    if (ModelState.IsValid)
    {
        _context.Add(AR);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    ViewData["UserID"] = new SelectList(_context.Bus, "nextNode", "NodeID", AR.NodeID);
    ViewData["MapID"] = new SelectList(_context.User, "SaveMap", "Map", AR.ID);
    return View(ARObject);
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

}
public async Task<IActionResult> makeEnrollement2(MapStatus PMap, MapStaus Cmap)
{
    var customer = await _context.User.FindAsync(username);
    ;
    DateTime t = bus.time;
    DateTime t2 = DateTime.Now;
    int timeCheck = DateTime.Compare(t, t2);
    int h = 0;
    if (timeCheck > 0 && Pmap.Capacity > 0)
    {
        bool check = true;
        string temp = "";
        while (check == true)
        {
            Random rnd = new Random();
            int num = rnd.Next(1000);
            temp = num.ToString();
            check = BookingExists(temp);
        }
        _context.Update(Cmap);
        _context.Add(Cmap);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Pmap");
    }
    await _context.SaveChangesAsync();
    return RedirectToAction("Create", "Pmap");
}

public async Task<IActionResult> customerRecord(string username)
{

    username = HttpContext.Session.GetString("Name");
    IEnumerable<Booking> filteringQuery =
    from records in _context.Booking
    where (records.userIdForeignkey == username)
    select records;

    int g = filteringQuery.Count();
    ICollection<Customer> record = new List<Customer>();



    if (filteringQuery.Count() == 0)
    {
        Booking b = new Booking();
        b.bookingID = "-";
        b.busIdForeignkey = "-";
        b.userIdForeignkey = "-";
        filteringQuery.Append(b);
    }


    ViewBag.data = filteringQuery;
    return View(filteringQuery);
}



    }

