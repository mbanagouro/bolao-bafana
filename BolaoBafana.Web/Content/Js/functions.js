/*! functions.js */
var Project = {

    $retorno: $('form span.retorno'),
    $inputNumero: $('input.numerico'),

    _init: function () {
        try {
            this.Interface();
            this.Eventos();
            this.Forms();
            this.Tabela();
            this.VerificarEmpate();
        } catch (e) {
            alert('Existem erros no script. Por favor verifique.');
            console.log('Error: ' + e.description);
        }
    },

    Interface: function () {
        /* Arredondar Cantos */
        if (!$.browser.msie) $('.round').corner("4px");

        /* Add Stripes */
        $('ul.stripes li:odd').addClass('stripe');
        $('ul.stripesP li.bilhete:odd').addClass('stripe');

        Project.ExpandirRecolher();
        Project.ReadOnly();
    },

    ExpandirRecolher: function () {
        $('a.expandirRecolher .expandir').click(function () {
            var $parent = $(this).parent();
            $parent.children('div.expandir').toggle();
            $parent.children('div.recolher').toggle();

            var $divFase = $(this).parents('div.Fase');
            if ($divFase.find('div.jogosDia').length)
                $divFase.find('div.jogosDia').slideDown();
            $divFase
            if ($divFase.find('div.palpiteCampeao').length)
                $divFase.find('ul.apostas').slideDown();

            return false;
        });

        $('a.expandirRecolher .recolher').click(function () {
            var $parent = $(this).parent();
            $parent.children('div.expandir').toggle();
            $parent.children('div.recolher').toggle();

            var $divFase = $(this).parents('div.Fase');
            if ($divFase.find('div.jogosDia').length)
                $divFase.find('div.jogosDia').slideUp();

            if ($divFase.find('div.palpiteCampeao').length)
                $divFase.find('ul.apostas').slideUp();

            return false;
        });

        $('div.Fase h2').click(function () {
            var $parent = $(this).parent();
            $parent.find('div.expandir').toggle();
            $parent.find('div.recolher').toggle();

            var $divFase = $(this).parents('div.Fase');
            if ($(this).parents().hasClass('palpiteCampeao')) {
                $divFase.find('ul.apostas').slideToggle();
            } else {
                $divFase.find('div.jogosDia').slideToggle();
            }
            return false;
        });
    },

    ReadOnly: function () {
        $.each($('ul.jogo.aberto input[type=text]'), function () {
            $(this).removeAttr("readonly");
        });
    },

    Eventos: function () {
        /* Painel Senha */
        $('a.mudarSenha, div.mudarSenha input.cancelar').click(function () {
            $('div.mudarSenha').slideToggle(300);
        });

        /* Controlar Recuperar */
        $('a.esqueciSenha').click(function () {
            $('li.recuperar').slideToggle();
            return false;
        });

        /* Toggle Jogos */
        $('a.cabecaDia').click(function () {
            if ($.browser.msie && $.browser.version < "8") {
                $(this).parent().children('div.jogosDia').toggle();
            } else {
                $(this).parent().children('div.jogosDia').slideToggle();
            }
            return false;
        });

        /* Toggle Apostas */
        $('div.cabecaJogo').click(function () {
            if ($.browser.msie && $.browser.version < "8") {
                $(this).parent().children('li.apostas').toggle();
            } else {
                $(this).parent().children('li.apostas').slideToggle();
            }
        });
    },

    Forms: function () {
        /* Máscaras */
        if (Project.$inputNumero.length) {
            Project.$inputNumero.somenteNumeros();
        }
    },

    Tabela: function () {
        $('table.ranking tbody tr:nth-child(1)').addClass('lider1');
        $('table.ranking tbody tr:nth-child(2)').addClass('lider2');
        $('table.ranking tbody tr:nth-child(3)').addClass('lider3');
    },

    // Verificar empate no mata-mata
    VerificarEmpate: function () {
        $('div.mata-mata div.cabecaJogo').click(function () { Verificar($(this).parent(), 'cabeca') });
        $('div.mata-mata li.apostas span.campos input[type=text]').change(function () { Verificar($(this).parent(), 'input') });

        function Verificar(e, local) {
            var caminho;

            if (local == 'cabeca') caminho = e.find('span.campos');
            else if (local == 'input') caminho = e;

            var placar = new Array();

            caminho.children('input[type=text]').each(function (i) {
                placar[i] = $(this).val();

                if (local == 'cabeca') {
                    if (placar[0] != "" && placar[0] == placar[1]) {
                        $(this).parent().children('span.penaltis').show();
                    }
                }
                else if (local == 'input') {
                    if (placar[0] == placar[1]) {
                        $(this).parent().children('span.penaltis').fadeIn();
                    } else {
                        $(this).parent().children('span.penaltis').fadeOut().find('input[type="radio"]').prop('checked', false);
                    }
                }
            });
        };
    },

    Ajax: function (options, mensagens) {
        var defaultMessages = {
            sucesso: 'Operação realizada com sucesso.',
            aguarde: 'Aguarde, realizando operação...'
        };
        var messages = $.extend({}, defaultMessages, mensagens);

        var defaultOptions = {
            form: '',

            onLoad: function () {
                Project.$retorno.fadeOut().text(messages.aguarde).fadeIn();
            },

            onError: function (XMLHttpRequest, textStatus, errorThrown) {
                var msg = "Ops! Não foi possível processar esta solicitação. Entre em contato conosco.",
                    result = $.parseJSON(XMLHttpRequest.responseText);

                if (result.Tipo === "System.ApplicationException") {
                    msg = result.Mensagem;
                }

                Project.$retorno.fadeOut().text(msg).fadeIn();
                setTimeout(function () { Project.$retorno.fadeOut(); }, 4000);
            },

            onSuccess: function (data) {
                Project.$retorno.fadeOut(function () {
                    Project.$retorno
                           .text(messages.sucesso)
                           .fadeIn()
                           .parents("form")
                           .find("input[type='text'], input[type='radio'], input[type='checkbox'], input[type='password'], select, textarea")
                           .val('');
                    setTimeout(function () { Project.$retorno.fadeOut(); }, 4000);
                });
            }
        };
        var settings = $.extend({}, defaultOptions, options);

        if (settings.form.length) {
            $.ajax({
                type: settings.form.attr('method'),
                url: settings.form.attr('action'),
                data: settings.form.serialize(),
                dataType: 'json',
                beforeSend: settings.onLoad,
                error: settings.onError,
                success: settings.onSuccess
            });
        }
    }
}

jQuery(function () {
    Project._init();
});