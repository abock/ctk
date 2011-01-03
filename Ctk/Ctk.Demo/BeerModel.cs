// 
// BeerModel.cs
//  
// Author:
//   Aaron Bockover <aaron@abock.org>
//
// Copyright 2011 Aaron Bockover
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

namespace Ctk.Demo
{
    public class BeerModel : List<string>
    {
        private static string [] beers = new string [] {
            "Bells Two Hearted Ale (Bells Brewery)",
            "Big Boss Aces and Ates (Big Boss Brewing Co.)",
            "Carolina Winter Porter (Carolina Brewing Co)",
            "Delirium Nocturnum (Huyghe Brewery)",
            "Dogfish Head 60 Minute IPA (Dogfish Head Craft Brewery)",
            "Dos Equis Amber (Cerveceria Cuauhtemoc Moctezum)",
            "Duck Rabbit Milk Stout (Duck Rabbit Brewery)",
            "Foothills Seeing Double IPA (Foothills Brewing Co.)",
            "Fullsteam Southern Lager (Fullsteam Brewery)",
            "Hebrew Jewbelation Vertical (Schmaltz Brewing Co.)",
            "Smuttynose IPA (Smuttynose Brewery)",
            "Stone Pale Ale (Stone Brewing Co.)",
            "Terrapin Hopsecutioner (Terrapin Beer Company)",
            "Abita Purple Haze (Abita Brewing Co.)",
            "Achel 8 Blonde (Brouwerij der Trappistenabdij De Achelse Kluis)",
            "Achel 8 Brune (Brouwerij der Trappistenabdij De Achelse Kluis)",
            "Aecht Rauchbier Marzen (Brauerei Heller Trum)",
            "Allagash Curieux (Allagash Brewing Co.)",
            "Allagash Hugh Malone (Allagash Brewing Co.)",
            "Allagash Victor (Allagash Brewing Co.)",
            "Allagash Victoria (Allagash Brewing Co.)",
            "Allagash White (Allagash Brewing Co.)",
            "Amstel Light (Amstel Brewing Company)",
            "Anchor Christmas 2009 (Anchor Brewery)",
            "Anchor Liberty Ale (Anchor Brewery)",
            "Anchor Steam (Anchor Brewery)",
            "Around the World Taster (unassigned)",
            "Asahi (Asahi Breweries)",
            "Avery Ellie's Brown Ale (Avery Brewing Co.)",
            "Avery IPA (Avery Brewing Co.)",
            "Avery Out of Bounds Stout (Avery Brewing Co.)",
            "Avery Reverend (Avery Brewing Co.)",
            "Avery Salvation (Avery Brewing Co.)",
            "Aviator Hogwild IPA (Aviator Brewing Company)",
            "Ayinger Altbairisch Dunkel (Ayinger)",
            "Ayinger Brau-Weisse (Ayinger)",
            "Ayinger Jahrhundert (Ayinger)",
            "Bass Ale (Bass Brewers)",
            "Battlefield Bock (Red Oak)",
            "Bear Republic Racer Five (Bear Republic Brewing Co.)",
            "Bear Republic Red Rocket Ale (Bear Republic Brewing Co.)",
            "Becks (Becks Brewery)",
            "Belgian Flight (unassigned)",
            "Belhaven Scottish Ale (Belhaven Brewery)",
            "Belhaven Scottish Stout (Belhaven Brewery)",
            "Belhaven Twisted Thistle (Belhaven Brewery)",
            "Bells Amber (Bells Brewery)",
            "Bells Pale Ale (Bells Brewery)",
            "Big Boss Angry Angel (Big Boss Brewing Co.)",
            "Big Boss Bad Penny Brown (Big Boss Brewing Co.)",
            "Big Boss Hells Belle (Big Boss Brewing Co.)",
            "Black Velvet (unassigned)",
            "Black n Tan (unassigned)",
            "Blanche De Bruxelles (Blanche De Bruxelles)",
            "Blue Moon (Coor's Brewing Co.)",
            "Boddingtons (Strangeways Brewery)",
            "Boont Amber (Anderson Valley Brewery)",
            "Boont ESB (Anderson Valley Brewery)",
            "Bosteels Pauwel Kwak (Brouwerij Bosteels)",
            "Bosteels Tripel Karmeliet (Brouwerij Bosteels)",
            "Boulder Beer Hazed and Infused (Boulder Brewing Co.)",
            "Boulder Beer Hazed and Infused (Boulder Brewing Co.)",
            "Boulder Beer Obovoid Oak-Aged Oatmeal Stout (Boulder Brewing Co.)",
            "Breckenridge Avalanche (Breckenridge Brewing Co.)",
            "Breckenridge Vanilla Porter (Breckenridge Brewing Co.)",
            "British Flight (unassigned)",
            "Brooklyn Brown (Brooklyn Brewery)",
            "Brooklyn Lager (Brooklyn Brewery)",
            "Brooklyn Local 1 (Brooklyn Brewery)",
            "Brooklyn Local 2 (Brooklyn Brewery)",
            "Brooklyn Pennant Pale (Brooklyn Brewery)",
            "Brooklyn Sorachi Ace (Brooklyn Brewery)",
            "Buckler (Heineken Brewery)",
            "Bud Light (Anheuser-Bush Brewery)",
            "Budweiser (Anheuser-Bush Brewery)",
            "Build Your Flight (unassigned)",
            "Carib Lager (Carib Brewery)",
            "Carolina Flight (unassigned)",
            "Carolina Pale Ale (Carolina Brewing Co)",
            "Carolina Strawberry Ale (Carolina Beer Company)",
            "Chimay Cinq Cents (Chimay)",
            "Chimay Grand Reserve (Chimay)",
            "Chimay Premiere (Chimay)",
            "Chocolate Truffle (unassigned)",
            "Coney Island Albino Python (Shmaltz Brewing Co.)",
            "Coors Light (Coor's Brewing Co.)",
            "Corona (Modelo Brewing)",
            "Cream of Wheat (unassigned)",
            "Czechvar (Budweiser Budvar)",
            "De Glazen Toren Saison d'Erpe-Mere (Kleinbrouwerij De Glazen Toren)",
            "Delirium Tremens (Huyghe Brewery)",
            "Der Hirschbrau Bavarian Weissbier (Der HirschBrau Hoss)",
            "Der Hirschbrau Doppel-Hirsch (Der HirschBrau Hoss)",
            "Dogfish Head 90 Minute IPA (Dogfish Head Craft Brewery)",
            "Dogfish Head Palo Santo (Dogfish Head Craft Brewery)",
            "Dos Equis Special Lager (Cerveceria Cuauhtemoc Moctezum)",
            "Duck Rabbit Brown Ale (Duck Rabbit Brewery)",
            "Duck Rabbit Porter (Duck Rabbit Brewery)",
            "Duvel (Brewery Moortgat)",
            "EKU 28 (Kulmbacher Brauerei)",
            "Eel River Acai Berry Wheat (Eel River Brewing Company)",
            "Eel River California Blonde Ale (Eel River Brewing Company)",
            "Eel River Organic India Pale Ale (Eel River Brewing Company)",
            "Eel River Raven's Eye Imperial Stout (Eel River Brewing Company)",
            "Eel River Triple Exultation (Eel River Brewing Company)",
            "Flying Dog Gonzo Imp. Porter (Flying Dog Brewery)",
            "Flying Dog In Heat Wheat (Flying Dog Brewery)",
            "Flying Dog Old Scratch (Flying Dog Brewery)",
            "Flying Dog Road Dog (Flying Dog Brewery)",
            "Foothills Hoppyum IPA (Foothills Brewing Co.)",
            "Fort Collins Retro Red (Fort Collins Brewery)",
            "Fort Collins Rocky Mountain IPA (Fort Collins Brewery)",
            "Fosters Oil Can (Carlton & United Breweries)",
            "Founders Centennial IPA (Founders Brewing Co.)",
            "Founders Dirty Bastard (Founders Brewing Co.)",
            "Founders Red's Rye (Founders Brewing Co.)",
            "French Broad Gateway Kolsch (French Broad Brewing Co.)",
            "French Broad Wee Heavier (French Broad Brewing Co.)",
            "Fullers ESB (Fuller's Brewery)",
            "Fullers London Porter (Fuller's Brewery)",
            "Fullers London Pride (Fuller's Brewery)",
            "German Flight (unassigned)",
            "Gouden Carolus Classic (Brouwerij Het Anker)",
            "Gouden Carolus Hopsinjoor (Brouwerij Het Anker)",
            "Gouden Carolus Tripel (Brouwerij Het Anker)",
            "Great Divide Denver Pale (Great Divide Brewing Co.)",
            "Great Divide Hercules IPA (Great Divide Brewing Co.)",
            "Great Divide Oak Aged Yeti (Great Divide Brewing Co.)",
            "Green Flash Le Freak (Green Flash Brewing Co.)",
            "Green Flash West Coast IPA (Green Flash Brewing Co.)",
            "Guinness Draught (Guinness & Son Co.)",
            "Haake Beck (Becks Brewery)",
            "Half and Half (unassigned)",
            "Harviestouns Ola Dubh (Harviestoun Brewery)",
            "Harviestouns Old Engine Oil (Harviestoun Brewery)",
            "HeBrew Genesis Ale (Shmaltz Brewing Co.)",
            "HeBrew Messiah Bold (Shmaltz Brewing Co.)",
            "Heavy Seas Loose Cannon (Clipper City Brewing Co.)",
            "Heavy Seas Marzen (Clipper City Brewing Co.)",
            "Hebrew Jewbelation 14 (Schmaltz Brewing Co.)",
            "Heineken (Heineken Brewery)",
            "Highland Black Mocha Stout (Highland Brewing Co.)",
            "Highland Gaelic (Highland Brewing Co.)",
            "Highland Oatmeal Porter (Highland Brewing Co.)",
            "Highland St Therese Pale (Highland Brewing Co.)",
            "Hitachino Nest White Ale (Kiuchi Brewery)",
            "Hofstetten Granitbock (Brauerei Hofstetten Krammer)",
            "Hook Norton Double Stout (Hook Norton Brewery)",
            "Hook Norton Old Hooky (Hook Norton Brewery)",
            "Hops 101 (unassigned)",
            "Hopus (Brasserie Lefebvre)",
            "Houblon Chouffe Dobbelen IPA (Brasserie D'achouffe)",
            "Hummingbird Water (Green Mountain Cidery)",
            "IBC (unassigned)",
            "Irish Car Bomb (Guinness Ltd)",
            "JK Scrumpys Apple Cider (Koan Family Orchards)",
            "Kaliber (Guinness & Son Co.)",
            "Kasteel Blonde (Brouwerji Van Honsebrouck)",
            "Kasteel Donker (Brouwerji Van Honsebrouck)",
            "Kasteel Triple (Brouwerji Van Honsebrouck)",
            "La Chouffe (Brasserie D'achouffe)",
            "Lagunitas A Little Sumpin Wild (Lagunitas Brewing  Company)",
            "Lagunitas Brown Shugga (Lagunita's Breweing)",
            "Lagunitas Dogtown Pale Ale (Lagunitas Brewing  Company)",
            "Lagunitas IPA (Lagunitas Brewing  Company)",
            "Lava Lamp (unassigned)",
            "Left Hand Milk Stout (Left Hand Brewing Co.)",
            "Leinenkugels Berry Weiss (Leinenkugel Brewing Co.)",
            "Leinenkugels Honey Weiss (Leinenkugel Brewing Co.)",
            "Lhasa Beer (Tibet Lhasa Brewery)",
            "Lime N' Lager (unassigned)",
            "Lindemans Cassis (Brouwerij Lindeman's)",
            "Lindemans Framboise (Brouwerij Lindeman's)",
            "Lindemans Kriek (Brouwerij Lindeman's)",
            "Lindemans Peche (Brouwerij Lindeman's)",
            "Lion Stout (Lion Brewery)",
            "Lone Rider Shotgun Betty (Lone Rider Brewing Co)",
            "Lonerider Sweet Josie (Lonerider Brewing)",
            "Lost Coast 8-Ball Stout (Lost Coast Brewing Co)",
            "Lost Coast Alley Cat Amber (Lost Coast Brewing Co)",
            "Lost Coast Downtown Brown (Lost Coast Brewing Co)",
            "Lost Coast Great White (Lost Coast Brewing Co)",
            "Lost Coast Indica IPA (Lost Coast Brewing Co)",
            "Lost Coast Pale Ale (Lost Coast Brewing Co)",
            "Lost Coast Rasberry Brown (Lost Coast Brewing Co)",
            "Mad River Jamaica Red (Mad River Brewing Co)",
            "Mad River Steelhead Extra Pale (Mad River Brewing Co)",
            "Mad River Steelhead Scotch Porter (Mad River Brewing Co)",
            "Magic Hat #9 (Magic Hat Brewing Company)",
            "Malheur 12 (Brouwerij De Landtsheer)",
            "Malts 101 (unassigned)",
            "Maredsous Triple (Moortgat Brewery)",
            "Mc Chouffe (Brasserie D'achouffe)",
            "Michelob Ultra (Anheuser-Bush Brewery)",
            "Mikkeller Beer Geek Breakfast (Mikkeller)",
            "Miller Lite (Miller Brewing Co.)",
            "Moinette Blond (Brasserie Dupont)",
            "Monty Pythons Holy Grail (Black Sheep Brewery)",
            "Moylans Hopsickle (Moylans Brewery)",
            "New Belgium 1554 (New Belgium Brewing Co.)",
            "New Belgium Fat Tire (New Belgium Brewing Co.)",
            "New Belgium Hoptober (New Belgium Brewing Co.)",
            "New Belgium La Folie (New Belgium Brewing Co.)",
            "New Belgium Ranger IPA (New Belgium Brewing Co.)",
            "New Belgium Vrienden (New Belgium Brewing Co.)",
            "New Grist Sorghum (Lakefront Brewery)",
            "New Holland Full Circle (New Holland Brewing Company)",
            "New Holland Hopivore (New Holland Brewing Company)",
            "Newcastle Brown Ale (Scottish & Courage Ltd)",
            "Nice Chouffe (Brasserie D'achouffe)",
            "North Coast Blue Star Wheat (North Coast Brewing Co.)",
            "North Coast Old #38 (Mendocino Brewing Co.)",
            "North Coast Old Rasputin (North Coast Brewing Co.)",
            "North Coast Old Stock (North Coast Brewing Co.)",
            "North Coast Pranqster (North Coast Brewing Co.)",
            "North Coast Red Seal (North Coast Brewing Co.)",
            "North Coast Scrimshaw Pilsner (North Coast Brewing Co.)",
            "Old Speckled Hen (Ruddles Brewing)",
            "Ommegang Abbey (Brewery Ommegang)",
            "Ommegang Adoration (Brewery Ommegang)",
            "Ommegang Hennepin (Brewery Ommegang)",
            "Ommegang Rare Vos (Brewery Ommegang)",
            "Ommegang Rare Vos (Brewery Ommegang)",
            "Ommegang Three Philosophers (Brewery Ommegang)",
            "Ommegang Witte (Brewery Ommegang)",
            "Orval Trappist (Brasserie d'Orval)",
            "Oskar Blues Dales Pale Ale (Oskar Blues Brewery)",
            "Oskar Blues Mama's Little Yella Pils (Oskar Blues Brewery)",
            "Oskar Blues Old Chub (Oskar Blues Brewery)",
            "Oskar Blues Ten FIDY (Oskar Blues Brewery)",
            "Pacifico (Modelo Brewing)",
            "Peroni (Peroni Breweries)",
            "Pete's Strawberry Blonde (Pete's Brewing Co.)",
            "Pilsner Urquell (Pilsner Urquell)",
            "Pinkus Ur Pilsner (Brauerei Pinkus Muller)",
            "Professor Fritz Briem 1809 Berliner Weisse (Weihensptephan Brewery)",
            "Raspberries N' Cream (unassigned)",
            "Red Oak (Red Oak)",
            "Red Stripe (Desnoes & Grodes)",
            "Redbridge Lager Gluten Free (Anheuser-Bush Brewery)",
            "Reissdorf Kolsch (Brauerei Heinrich Reissdorf)",
            "Rochefort 10 (Brasserie Rochefort)",
            "Rochefort 8 (Brasserie Rochefort)",
            "Rogue American Amber (Rogue Ales)",
            "Rogue Chocolate Stout (Rogue Ales)",
            "Rogue Hazelnut Brown Nectar (Rogue Ales)",
            "Rogue Shakespeare Stout (Rogue Ales)",
            "Rogue XS Imperial Stout (Rogue Ales)",
            "Saint Somewhere Lectio Divina (Saint Somewhere Brewing Company)",
            "Saint Somewhere Saison Athene (Saint Somewhere Brewing Company)",
            "Saison Dupont (Brasserie Dupont)",
            "Sam Adams Cherry Wheat (Boston Brewing Co)",
            "Sam Adams Double Bock (Boston Brewery)",
            "Sam Adams Imperial Stout (Boston Brewing Co)",
            "Sam Adams Imperial White (Boston Brewing Co)",
            "Sam Adams Infinium (Boston Brewing Co)",
            "Sam Adams Light (Boston Brewing Co)",
            "Sam Adams Winter Lager (Boston Brewery)",
            "Samuel Smith IPA (The Old Brewery)",
            "Samuel Smith Imperial Stout (The Old Brewery)",
            "Samuel Smith Nut Brown Ale (The Old Brewery)",
            "Samuel Smith Oatmeal Stout (The Old Brewery)",
            "Samuel Smith Pale Ale (The Old Brewery)",
            "Samuel Smith Taddy Porter (The Old Brewery)",
            "Schneider Aventinus (G Schneider & Sohn)",
            "Schneider Edel-Weiss (G Schneider & Sohn)",
            "Schneider Weisse (G Schneider & Sohn)",
            "Sea Dog Blueberry Wheat (Shipyard Brewing Co)",
            "Sea Dog Raspberry Wheat (unassigned)",
            "Sierra Nevada Celebration (Sierra Nevada Brewing Co.)",
            "Sierra Nevada Kellerweis (Sierra Nevada Brewing Co.)",
            "Sierra Nevada Pale Ale (Sierra Nevada Brewing Co.)",
            "Sierra Nevada Torpedo IPA (Sierra Nevada Brewing Co.)",
            "Ska Brown Ale (unassigned)",
            "Ska Decadent Imperial IPA (SKA Brewing Co.)",
            "Ska Modus Hoperandi (SKA Brewing Co.)",
            "Ska Pinstripe Red (unassigned)",
            "Ska Porter (unassigned)",
            "Ska Special ESB (SKA Brewing Co.)",
            "Ska True Blonde (unassigned)",
            "Smithwicks Ale (Guinness & Son Co.)",
            "Snake Bite (unassigned)",
            "Sol (Cerveceria Cuauhtemoc Moctezum)",
            "Spaten Franziskaner Dunkel Weisse (Spaten-Franziskaner Brau)",
            "Spaten Franziskaner Hefe-Weiss (Spaten-Franziskaner Brau)",
            "Spaten Lager (Spaten-Franziskaner Brau)",
            "Spaten Oktoberfest (Spaten-Franziskaner Brau)",
            "Spaten Optimator (Spaten-Franziskaner Brau)",
            "St Martin Blonde (Brasserie de Brunhaut)",
            "St Pauli Girl Lager (Bremen Breweries)",
            "Stella Artois (Brasserie Artois)",
            "Stone Arrogant Bastard Ale (Stone Brewing Co.)",
            "Stone IPA (Stone Brewing Co.)",
            "Stone Ruination IPA (Stone Brewing Co.)",
            "Stone Smoked Porter (Stone Brewing Co.)",
            "Stoudts Heifer-In-Wheat (Stoudts Brewing Co.)",
            "Stoudts Pilsner (Stoudts Brewing Co.)",
            "SweetWater 420 Extra Pale Ale (SweetWater Brewing Co.)",
            "SweetWater Blue (Strangeways Brewery)",
            "Sweetwater Festive Ale (SweetWater Brewing Co.)",
            "Tecate (Cauauhte'moc Breweries)",
            "Terrapin Double Feature (Terrapin Beer Company)",
            "Terrapin Wake and Bake (Terrapin Beer Company)",
            "The Bruery Mischief (The Bruery)",
            "The Bruery Orchard White (The Bruery)",
            "The Bruery Saison Rue (The Bruery)",
            "USA Flight (unassigned)",
            "Unibroue Blanche de Chambly (Unibroue)",
            "Unibroue Don De Dieu (Unibroue)",
            "Unibroue Ephemere (Unibroue)",
            "Unibroue La Fin Du Monde (Unibroue)",
            "Unibroue Maudite (Unibroue)",
            "Unibroue Trois Pistoles (Unibroue)",
            "Urthel Samaranth (Brouwerij Van Steenberge)",
            "Victory Donnybrook Stout (Victory Brewing Co)",
            "Victory Prima Pilsner (Victory Brewing Co)",
            "Warsteiner (Warstein Brau-haus)",
            "Warsteiner Dunkel (Warstein Brau-haus)",
            "Wells Banana Bread (Charles Wells Pub Co.)",
            "Westmalle Dubbel (Brouwerij der Trappisten van Westmalle)",
            "Westmalle Tripel (Brouwerij der Trappisten van Westmalle)",
            "Weyerbacher Simcoe IPA (Weyerbacher Brewing Co.)",
            "Weyerbacher Tiny (Weyerbacher Brewing Co.)",
            "Woodchuck Amber (Green Mountain Cidery)",
            "Woodchuck Granny Smith (Green Mountain Cidery)",
            "Woodchuck Pear Cider (Green Mountain Cidery)",
            "Wychwood Hobgoblin (Wychwood Brewery)",
            "Youngs Double Chocolate Stout (Young & Co. Brewing)",
            "Youngs Double Chocolate Stout Ice Cream Float (Young & Co. Brewing)",
            "Yuengling Lager (Yuengling & Son Brewery)",
            "Allagash Four (Allagash Brewing Co.)",
            "Sam Adams Cream Stout (Boston Brewery)",
            "The Bruery Three French Hens (The Bruery)",
            "Wolavers Alta Gracia Coffee Porter (Wolaver Brewery)",
            "Anchor Porter (Anchor Brewery)",
            "Bells Expedition Stout (Bells Brewery)",
            "Boulder Beer Sweaty Betty (Boulder Brewing Co.)",
            "Brooklyn Black Ops (Brooklyn Brewery)",
            "Dogfish Head Burton Baton (Dogfish Head Craft Brewery)",
            "Fantome Noel (Brasserie de Fantome)",
            "Fort Collins Kidd Lager (Fort Collins Brewery)",
            "Founders Nemesis 2010 (Founders Brewing Co.)",
            "Lonerider Belle Starr (Lone Rider Brewing Co)",
            "Mikkeller Beer Geek Brunch (Mikkeller)",
            "The Bruery Three French Hens (The Bruery)",
            "Widmer Brrbon (Widmer Brothers)"
        };

        public BeerModel () : base (beers)
        {
        }
    }
}

