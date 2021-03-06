﻿using System;

namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        
        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void incrementarQteMovimentos() {
            qteMovimentos++;
        }

        public bool existemMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool existemCapturasPossiveis() {
            bool[,] mat = capturasPossiveis();
            for (int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool existemCapturasPossiveis(SentidoDoMovimento movimentacao) {
            bool[,] mat = capturasPossiveis(movimentacao);
            for (int i = 0; i < tab.linhas; i++) {
                for (int j = 0; j < tab.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool existeAmigo(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p.cor == cor;
        }

        protected bool existeInimigo(Posicao pos) {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        protected bool casaLivre(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null;
        }        

        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public bool capturaPossivel(Posicao pos) {
            return capturasPossiveis()[pos.linha, pos.coluna];
        }

        public bool capturaPossivel(Posicao pos, SentidoDoMovimento movimentacao) {
            return capturasPossiveis(movimentacao)[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();

        public abstract bool[,] capturasPossiveis();

        public abstract bool[,] capturasPossiveis(SentidoDoMovimento movimentacao);
    }
}
