﻿/*
 * This file is part of alphaTab.
 * Copyright (c) 2014, Daniel Kuschny and Contributors, All rights reserved.
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
using AlphaTab.Model;
using AlphaTab.Rendering.Utils;

namespace AlphaTab.Rendering.Glyphs
{
    public class ScoreTieGlyph : TieGlyph
    {
        private readonly Note _startNote;
        private readonly Note _endNote;

        public ScoreTieGlyph(Note startNote, Note endNote, Glyph parent, bool forEnd = false)
            : base(startNote.Beat, endNote.Beat, parent, forEnd)
        {
            _startNote = startNote;
            _endNote = endNote;
        }

        public override void DoLayout()
        {
            base.DoLayout();
            YOffset = (NoteHeadGlyph.NoteHeadHeight/2);
        }

        protected override BeamDirection GetBeamDirection(Beat beat, BarRendererBase noteRenderer)
        {
            return ((ScoreBarRenderer)noteRenderer).GetBeatDirection(beat);
        }

        protected override float GetStartY(BarRendererBase noteRenderer, BeamDirection direction)
        {
            return noteRenderer.GetNoteY(_startNote);
        }

        protected override float GetEndY(BarRendererBase noteRenderer, BeamDirection direction)
        {
            return noteRenderer.GetNoteY(_endNote);
        }

        protected override float GetStartX(BarRendererBase noteRenderer)
        {
            return noteRenderer.GetNoteX(_startNote);
        }

        protected override float GetEndX(BarRendererBase noteRenderer)
        {
            return noteRenderer.GetNoteX(_endNote);
        }
    }
}
