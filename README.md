# Sistema de Partículas [![Build Status](https://github.com/ricardodalarme/Particles-System/workflows/Master/badge.svg)](https://github.com/ricardodalarme/Particles-System/actions)

 * [Introdução](#introdução)
 * [Estrutura](#estrutura)
    * [Emissor](#emissor)
    * [Partícula](#partícula)
 * [Atributos](#atributos)
 * [Exemplos](#exemplos)
 * [Como Executar](#como-executar)

## Introdução

Um sistema de partículas é uma estrutura que permite simular partículas de diferentes tipos de maneira orgânica, com a vantagem de apenas ajustar algumas propriedades das partículas para obter os resultados exatos desejados com rapidez e sem esforço. E a melhor parte: você não precisa desenhar nenhuma dessas partículas. Você só precisa de uma textura base e isso é tudo. O sistema ficará encarregado de renderizar as partículas, os efeitos (como brilho), cálculos físicos, taxa de emissão e assim por diante. Você não precisa se preocupar com nada, apenas brincar com isso para conseguir o que deseja.

Nesse projeto foi desenvolvido um sistema de partículas na linguagem C# utilizando uma versão adaptada à plataforma .NET da biblioteca gráfica [SFML](https://github.com/SFML/SFML), sendo que foi desenvolvida baseado do OpenGL. Além disso, foi utilizado a biblioteca [DarkUI](https://github.com/RobinPerris/DarkUI) para a criação da interface com modo escuro.

## Estrutura

### Emissor

Os sistemas de partículas geralmente contêm o que é conhecido como emissor. Um emissor é o objeto responsável por gerar todas as partículas e definir o comportamento das partículas e suas propriedades. Um emissor é responsável pelas seguintes coisas:

- Controlar a taxa de emissão de partículas. Basicamente, quantas partículas são geradas por quadro.
- A posição onde as partículas são geradas.
- Velocidade e movimento das partículas.
- Tempo de vida de partículas.
- Outras propriedades das partículas, como cores, transparência ou tamanho.
- O próprio emissor contém todas as partículas que serão atualizadas e morrerão com o tempo. 

Todos esses dados são transferidos do emissor para todas as partículas, de modo que se comportem como deveriam. A alteração desses dados mudará o comportamento das partículas naquele emissor.

### Partícula

As partículas herdam suas propriedades do emissor de onde vieram. Mas o que é exatamente a própria partícula? A partícula em si é apenas uma textura simples em movimento que é renderizada na tela.

Essa textura pode ser qualquer coisa que quisermos que se ajuste ao nosso propósito. Geralmente é uma textura difusa e branca que será tingida quando renderizada. Um bom exemplo é este conjunto de texturas de partículas abaixo:

![](https://user-images.githubusercontent.com/25589509/38513650-29411102-3c2f-11e8-85b7-f3d5725da3f3.jpg)

As propriedades das partículas podem ser o que você desejar. As possibilidades são infinitas. Você pode mudar o que quiser e essa flexibilidade permite gerar quase qualquer tipo de partícula que você possa imaginar. Você pode escolher o tamanho, a cor, a velocidade, a forma do emissor, a textura e muito mais.

As duas principais funções do sistema são Update e Reset que estão presentes na classe _Particle.cs_. É através delas que acontece o controle da criação, movimentação e morte de cada partícula com base nos atributos selecionados para o fluxo.

~~~cs
public void Update(Time elapsed)
{
    _lifeTime -= elapsed;

    // if the particle is dead, respawn it
    if (_lifeTime <= Time.Zero) Reset();

    // update the particle properties
    Color = CurrentColor;
    Scale = new Vector2f(CurrentSize / Textures[_pool.Texture].Size.X, CurrentSize / Textures[_pool.Texture].Size.Y);
}

private void Reset()
{
    // give a random velocity and lifetime to the particle
    var angle = Randomizer.Next(_pool.AngleRangeMin, _pool.AngleRangeMax) * 3.14f / 180.0;
    float speed = Randomizer.Next(_pool.SpeedMinRand, _pool.SpeedMaxRand) + _pool.Speed;
    _velocity = new Vector2f((float)(Math.Cos(angle) * speed), (float)(Math.Sin(angle) * speed));
    _lifeTime = Time.FromMilliseconds(Randomizer.Next(_pool.LifeTimeMinRand, _pool.LifeTimeMaxRand) + _pool.LifeTime);

    // reset the position of the corresponding vertex
    Position = _pool.Emitter;
}
~~~

## Atributos

| Atributo        | Descrição                                         |
|-----------------|---------------------------------------------------|
| Angle Range     | Espectro de ângulo do fluxo de partículas.        |
| Speed           | Velocidade em que as partículas se movem.         |
| Start/End Size  | Tamanho das partículas ao nascer e ao morrer.     |
| Start/End Color | Cor das partículas ao nascer e ao morrer.         |
| Life Time       | Quantos milissegundos uma partícula vive.         |
| Texture         | Textura das partículas do fluxo.                  |
| Count           | Quantidade de partículas dentro do fluxo.         |
| Follow Mouse    | Define se a emissão da partícula seguirá o mouse. |

## Exemplos

![](https://im4.ezgif.com/tmp/ezgif-4-c13083279551.gif)
![](https://im4.ezgif.com/tmp/ezgif-4-49d0f82602b6.gif)
![](https://im4.ezgif.com/tmp/ezgif-4-162979b9d17c.gif)

## Como Executar

Certifique-se de ter o Visual Studio 2017 Community (ou posterior) instalado.

- Clone o código: git clone https://github.com/ricardodalarme/Particles-System.git
- Abra Particles.sln
- Restaure pacotes Nuget
- Compile
- Adicione as [texturas](https://drive.google.com/file/d/12jB6_PdeZsp3wsqKmCy65ESouolvbl5G/view?usp=sharing) à pasta de compilação
- Agora é só executar!
