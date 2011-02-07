﻿using FarseerPhysics.DebugViews;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace FarseerPhysics.DemoBaseXNA.DemoShare
{
    public class Agent
    {
        private Body _agentBody;
        private Category _collidesWith;

        private Category _collisionCategories;

        public Agent(World world, Vector2 position)
        {
            _collidesWith = Category.All;
            _collisionCategories = Category.All;

            _agentBody = BodyFactory.CreateBody(world, position);
            _agentBody.BodyType = BodyType.Dynamic;

            DebugMaterial matBody = new DebugMaterial(MaterialType.Blank)
                                        {
                                            Color = Color.LightGray
                                        };
            DebugMaterial matHands = new DebugMaterial(MaterialType.Squares)
                                         {
                                             Color = Color.DarkOrange,
                                             Scale = 8f,
                                             Depth = 0.0f
                                         };

            //Center
            FixtureFactory.AttachCircle(1, 1, _agentBody, matBody);

            //Left arm
            FixtureFactory.AttachRectangle(3, 0.8f, 1, new Vector2(-2, 0), _agentBody, matBody);
            FixtureFactory.AttachCircle(1, 1, _agentBody, new Vector2(-4, 0), matHands);

            //Right arm
            FixtureFactory.AttachRectangle(3, 0.8f, 1, new Vector2(2, 0), _agentBody, matBody);
            FixtureFactory.AttachCircle(1, 1, _agentBody, new Vector2(4, 0), matHands);

            //Top arm
            FixtureFactory.AttachRectangle(0.8f, 3, 1, new Vector2(0, 2), _agentBody, matBody);
            FixtureFactory.AttachCircle(1, 1, _agentBody, new Vector2(0, 4), matHands);

            //Bottom arm
            FixtureFactory.AttachRectangle(0.8f, 3, 1, new Vector2(0, -2), _agentBody, matBody);
            FixtureFactory.AttachCircle(1, 1, _agentBody, new Vector2(0, -4), matHands);
        }

        public Category CollisionCategories
        {
            get { return _collisionCategories; }
            set
            {
                _collisionCategories = value;
                Body.CollisionCategories = value;
            }
        }

        public Category CollidesWith
        {
            get { return _collidesWith; }
            set
            {
                _collidesWith = value;
                Body.CollidesWith = value;
            }
        }

        public Body Body
        {
            get { return _agentBody; }
        }
    }
}