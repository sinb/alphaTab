﻿/*
 * This file is part of alphaTab.
 * Copyright © 2018, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using AlphaTab.Collections;
using AlphaTab.Model;

namespace AlphaTab.Rendering
{
    /// <summary>
    /// This is the base public class for creating factories providing BarRenderers
    /// </summary>
    abstract class BarRendererFactory
    {
        public bool IsInAccolade { get; set; }
        public bool HideOnMultiTrack { get; set; }
        public bool HideOnPercussionTrack { get; set; }
        public abstract string StaffId { get; }

        protected BarRendererFactory()
        {
            IsInAccolade = true;
            HideOnPercussionTrack = false;
            HideOnMultiTrack = false;
        }

        public virtual bool CanCreate(Track track, Staff staff)
        {
            return !HideOnPercussionTrack || staff.StaffKind != StaffKind.Percussion;
        }
        public abstract BarRendererBase Create(ScoreRenderer renderer, Bar bar, StaveSettings staveSettings);
    }
}
