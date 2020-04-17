using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CJmod.Items
{
     public class Scorcher : ModItem
     {
     public override void SetStaticDefaults()
         {
          DisplayName.SetDefault("Scorcher");
         Tooltip.SetDefault("Lights wooden arrows on fire");
          Tooltip.SetDefault ("Burn baby burn!");
         }

     public override void SetDefaults()
         {
         item.damage = 30;
         item.ranged = true;
         item.width = 24;
         item.height = 38;
         item.maxStack = 1;
         item.useTime = 20;
         item.useAnimation = 20;
         item.useStyle = 5;
         item.knockBack = 3;
         item.value = 500000;
         item.rare = 2;
         item.UseSound = SoundID.Item5;
         item.noMelee = true;
         item.shoot = ProjectileID.FireArrow;
         item.useAmmo = AmmoID.Arrow;
         item.shootSpeed = 45f;
         item.autoReuse = false;
         }
		 	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
	        {
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.FireArrow;
			}
		float numberProjectiles = 3; // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
		        

	     	}
			return false;
			}
     public override void AddRecipes()
         {
         ModRecipe recipe = new ModRecipe (mod);
         recipe.AddIngredient(ItemID.MoltenFury,1);
         recipe.AddIngredient(ItemID.LivingFireBlock,10);
		 recipe.AddIngredient(ItemID.SoulofMight,10);
         recipe.AddTile(TileID.MythrilAnvil);
         recipe.SetResult(this);
         recipe.AddRecipe();
         }
    
}
}