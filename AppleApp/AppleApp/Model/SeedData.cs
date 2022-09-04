using AppleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AppleApp.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Apple == null)
                {
                    throw new ArgumentNullException("Null ApplicationDbContext");
                }



                // Look for any apples.
                
                if (context.Apple.Any())
                {
                    return;   // DB has been seeded
                }

                context.Apple.AddRange(
                    new Apple
                    {

                        Name = "Granny Smith",
                        Location = "NEW SOUTH WALES,AUSTRLIA",
                        Rate = 4.1,
                        Rank = 1,
                        Description = "These world-famous green apples actually have Australian origins. According to legend, Maria Ann Smith found an apple seedling near her house in 1868. Shortly thereafter, it began to bear light green colored apples which proved to be perfect for both eating and cooking. Granny Smith apples were first commercially grown in New South Wales in 1895, and today, they are one of the most popular apple varieties in the world, characterized by their green exterior with a slight pink blush, bright white flesh, and firm texture.The flavor can best be described as crisp with a strong tartness that’s reminiscent of lemons.When used raw,these apples pair well with sharp cheeses.Granny Smiths also hold their shape extremely well during baking,so they are mostly used in pies,cobblers, cakes,  muffins, and tarts.",
                        ImgUrl = "https://cdn.tasteatlas.com/Images/Ingredients/7ea01754d8a24c4d939bcb841c4eab8f.jpg?mw=1300"
                    },
                    new Apple
                    {

                        Name = "Gala",
                        Location = "NEW ZEALAND",
                        Rate = 3.5,
                        Rank = 2,
                        Description = "Gala is a variety of (typically) round-shaped apples characterized by their reddish-yellow color and a firm, crisp, yellow-tinged interior. Their flavor is slightly sweet with hints of vanilla, along with an accompanying floral aroma. The apples were discovered in 1934 in New Zealand by an orchardist named J.H.Kidd.Today,Gala apples are usually consumed fresh or used in salads and sauces.",
                        ImgUrl = "https://cdn.tasteatlas.com/images/ingredients/c5d2a872328f406789602786e078def2.jpg?mw=1300"
                    },
                    new Apple
                    {

                        Name = "Fuji Apples",
                        Location = "AOMORI PREFECTURE,JAPAN",
                        Rate = 4.0,
                        Rank = 3,
                        Description = "Fuji is a Japanese variety of apple that was produced by cross-pollination of the Red Delicious and Virginia Ralls Janet varieties back in the late 1930s. This apple is distinguished by a red-yellow skin that surrounds its creamy white flesh that's renowned for its exceptional sweetness, low acidity, juiciness, firmness, and crispiness.Owing to their excellent characteristics and their long shelf - life,these refreshing and fragrant apples are nowadays among the most commonly grown apple varieties around the world.They're expensive because the climate in Japan is not suitable for growing apples, so each one needs to be wrapped in cellophane while it\'s still growing on trees.The apples’ name is believed to have been derived from the town of Fujisaki, which is the home of the Tohoku Research Station where Fuji apples were first cultivated.Apart from consuming them raw as a sweet,juicy snack,the apples can also be enjoyed with sharp cheeses,and they are suitable for cooking in various ways including baking, roasting, or boiling.Fuji apples are incredibly versatile and can be used in both sweet and savory dishes such as pies, strudels, pizza toppings, quiches, sauces, soups, salads, or curries, but they can also be made into a variety of apple products such as candied apples, apple wine or juice, and delicious apple jams.",
                        ImgUrl = "https://cdn.tasteatlas.com/images/ingredients/86e345e9089c42bd88192c4e327c2f45.jpg?mw=1300"
                    }


                );


                 var recipes = new Recipe[]
               {
                      new Recipe{
                          Name="Apple Pie",
                          Category="DESSERT",
                          Rate=4.2,
                          Description="Although England has a long history of making meat and fruit pies, and it was the inspiration for the American versions, there is nothing that is more synonymous with American desserts than the apple pie. In the United States, apple pies are found everywhere from big grocery shops and restaurants to coffee shops and home bakers, baked until the double crust is golden brown, filled with cinnamon-sugar coated apples.omemade American apple pie is a source of great pride, causing arguments about which apple variety is the most suitable for the best pies.Some swear by Granny Smiths, but they are sour and require too much sugar, resulting in a soggy crust.Others prefer Golden Delicious, the driest, but the least flavorful variety.Experts opt for the tart Cortland or the flavorful Northern Spy varieties, both at their prime between September and November.",
                          ImgUrl="https://cdn.tasteatlas.com/Images/Dishes/ca6ef74dca69400991b6723caa3a1f0b.jpg?mw=1300",
                          AppleID=1011 }
               };

                  context.Recipe.AddRange(recipes);


                    var wines = new Wine[]
                 {
                          new Wine{
                              Name="Applejack",
                              Category="APPLE BRANDY",
                              Rate=4.1,
                              Location = "NEW JERSEY, United States of America",
                              Description="Applejack is often dubbed as one of the oldest American spirits. Essentially, it is an apple brandy that supposedly originated during colonial times. It is believed that the original version was made as a cider that was fermented and left to freeze.The liquid that was not frozen would then be consumed. However, this technique, known as freeze distillation or jacking is not practiced anymore. The turning point for applejack production happened in 1698 when a Scotsman William Laird moved to New Jersey.He was familiar with distillation and started distilling apple brandy.In 1780, his great - grandson Robert Laird founded Laird & Company that would become the first licensed distillery in the United States, and to this day, the leading name when it comes to apple - based spirits. .",
                              ImgUrl="https://cdn.tasteatlas.com/images/ingredients/63f36877787d460b9915b120cef50344.jpg?mw=1300",
                              AppleID=1013 
                          },
                          new Wine{
                              Name="Lambig",
                              Category="APPLE BRANDY",
                              Rate=4.5,
                              Location = "BRITTANY, France",
                              Description="Lambig is an oak-aged brandy distilled from apple cider. It hails from Brittany, where it originated as a farm brandy that was mainly distilled for local consumption. The brandy is now commercially produced and has become one of the traditional regional products.When the brandy is distilled, it is oak-aged for several years. It results in a golden or amber - colored drink with pleasant aromas reminiscent of apples, warming spices, and nuts, along with distinctive woody and spicy notes.Lambig is best served as an aperitif or a digestif, and it should always be slowly sipped.It is bottled at 40 % ABV.To be classified as a protected AOC product, it must be aged for a minimum of two years. " ,
                              ImgUrl="https://cdn.tasteatlas.com/images/ingredients/51140623d7834daa8f53dc5915de30b7.jpg?mw=1300",
                              AppleID=1012
                          }
                 };

                context.Wine.AddRange(wines);

                context.SaveChanges();





            }
        }
    }
}
